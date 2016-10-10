using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PestControl.Dao;
using PestControl.Model.Entity;
using PestControl.Services.Base;
using PestControl.Core;
using PestControl.Services.Models;

namespace PestControl.Services
{
    public interface IMenuService : IBaseService
    {

        void Save(Model.Entity.Menu menu);
        IPagedList<MenuShortDetailModel> GetMenuList(int pageIndex, int pageSize);
        IPagedList<MenuShortDetailModel> GetSubMenuList(int pageIndex, int pageSize);
        Menu GetById(long id);
        ProductServices GetSubMenuById(long id);

        IList<Menu> GetMenuList();
        string CreateFriendlyUrl(string name);
        void Save(ProductServices subMenu);

        Menu GetMenuByFriendlyUrl(string friendlyUrl);
        ProductServices GetSubMenuByFriendlyUrl(string friendlyUrl);

        IList<Menu> GetActiveMenus();
        IList<ProductServices> GetActiveSubMenus(long menuId);

        ProductServices LoadSubmenuById(long id);

        bool IsUpdateSuccessfully(ProductServices submenu, long id);

        IList<ProductServices> GetActiveSubMenusOnly(long id);

        IList<Menu> GetActiveMenuList(int index, int pageSize);

        Menu LoadMenuById(long id);

        bool IsUpdateMenuSuccessfully(Menu menu, long p);

        IList<Menu> GetActiveMenusOnly();
    }

    public class MenuService : BaseService, IMenuService
    {
        private readonly IMenuDao _menuDao;
        private readonly ISubMenuDao _subMenuDao;

        public MenuService(ISession session)
        {
            _session = session;
            _menuDao = new MenuDao() { Session = _session };
            _subMenuDao = new SubMenuDao() { Session = _session };
        }
        public Menu LoadMenuById(long id)
        {
            return _session.QueryOver<Menu>().Where(x => x.Id == id).SingleOrDefault<Menu>();
        }
        public IList<Menu> GetActiveMenuList(int index, int pageSize)
        {
            return _session.QueryOver<Menu>().Where(x => x.Status == 1).List();
        }
        public bool IsUpdateMenuSuccessfully(Menu menu, long id)
        {
            using (var trans = _session.BeginTransaction())
            {
                try
                {
                    var prevObj = LoadMenuById(id);
                    prevObj.Status = menu.Status;
                    _session.Update(prevObj);
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return false;
                }

            }
        }
        public bool IsUpdateSuccessfully(ProductServices submenu, long id)
        {
            using (var trans = _session.BeginTransaction())
            {
                try
                {
                    var prevObj = LoadSubmenuById(id);
                    prevObj.Status = submenu.Status;
                    _session.Update(prevObj);
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return false;
                }

            }
        }
        public ProductServices LoadSubmenuById(long id)
        {
            return _session.QueryOver<ProductServices>().Where(x => x.Id == id).SingleOrDefault<ProductServices>();
        }
        public IList<Menu> GetActiveMenus()
        {
            return _session.QueryOver<Menu>().Where(x => x.Status != -404).List();
        }

        public IList<ProductServices> GetActiveSubMenus(long menuId)
        {
            return _session.QueryOver<ProductServices>().Where(x => x.Status != -404 && x.Menu.Id == menuId).List();
        }
        public IList<Menu> GetActiveMenusOnly()
        {
            return _session.QueryOver<Menu>().Where(x => x.Status == 1).List();
        }
        public IList<ProductServices> GetActiveSubMenusOnly(long menuId)
        {
            return _session.QueryOver<ProductServices>().Where(x => x.Status == 1 && x.Menu.Id == menuId).List();
        }

        public Menu GetMenuByFriendlyUrl(string friendlyUrl)
        {
            return _session.QueryOver<Menu>().Where(x => x.FriendlyUrl == friendlyUrl && x.Status > 0).SingleOrDefault();
        }
        public ProductServices GetSubMenuByFriendlyUrl(string friendlyUrl)
        {
            return _session.QueryOver<ProductServices>().Where(x => x.FriendlyUrl == friendlyUrl && x.Status > 0).SingleOrDefault();
        }

        public void Save(ProductServices subMenu)
        {
            if (subMenu.Id > 0)
                _subMenuDao.Update(subMenu);
            else
                _subMenuDao.Save(subMenu);
        }

        public string CreateFriendlyUrl(string name)
        {
            var friendlyUrls = new List<string>();
            var legalUrl = string.Empty;

            //Get FriendlyUrl From User where FirstName(lowercase) == firstname(lowercase) && LastName(lowercase) == lastname(lowercase);

            friendlyUrls = _session.QueryOver<Menu>().Where(x => x.Title == name).Select(x => x.FriendlyUrl).List<string>().ToList();
            var subMenuFriendlyUrlList = _session.QueryOver<ProductServices>().Where(x => x.Title == name).Select(x => x.FriendlyUrl).List<string>().ToList();
            friendlyUrls.AddRange(subMenuFriendlyUrlList);

            legalUrl = (name.ToLower()).ToLegalUrl();


            legalUrl = legalUrl.TrimEnd(' ');
            IList<int> numbers = new List<int>();

            if (friendlyUrls.Count > 0)
            {
                foreach (var item in friendlyUrls)
                {
                    var temp = item.Replace(legalUrl, "");
                    temp = temp.Replace("-", "");
                    var num = 0;
                    if (Int32.TryParse(temp, out num))
                    {
                        numbers.Add(num);
                    }
                }

                if (numbers.Count > 0)
                {
                    return legalUrl + "-" + (numbers.Max() + 1).ToString();
                }
                else
                {
                    legalUrl += "-" + (numbers.Count + 1).ToString();

                    //Get * From User table where friendlyUrl (lower) = legalUrl. Return all matched list.
                    var duplicates = _session.QueryOver<Menu>().Where(x => x.FriendlyUrl == legalUrl).List().ToList();
                    duplicates.AddRange(_session.QueryOver<Menu>().Where(x => x.FriendlyUrl == legalUrl).List().ToList());

                    if (duplicates.Count > 0)
                    {
                        return legalUrl + "-" + (duplicates.Count + 1).ToString();
                    }

                    return legalUrl;
                }
            }
            else
            {

                //Get * From User table where friendlyUrl (lower) = legalUrl. Return all matched list.
                var duplicates = _session.QueryOver<Menu>().Where(x => x.FriendlyUrl == legalUrl).List().ToList();
                duplicates.AddRange(_session.QueryOver<Menu>().Where(x => x.FriendlyUrl == legalUrl).List().ToList());

                if (duplicates.Count > 0)
                {
                    return legalUrl + "-" + duplicates.Count.ToString();
                }
            }

            return legalUrl;
        }

        public IList<Menu> GetMenuList()
        {
            return _session.QueryOver<Menu>().Where(x => x.Status != -404).List().ToList();
        }
        public ProductServices GetSubMenuById(long id)
        {
            return (ProductServices)_subMenuDao.LoadById(id);
        }

        public Menu GetById(long id)
        {
            return _session.QueryOver<Menu>().Where(x => x.Id == id).SingleOrDefault<Menu>();
        }

        public void Save(Menu menu)
        {
            if (menu.Id > 0)
                _menuDao.Update(menu);
            else
                _menuDao.Save(menu);
        }

        public IPagedList<MenuShortDetailModel> GetMenuList(int pageIndex, int pageSize)
        {
            var query = _session.QueryOver<Menu>().Where(x => x.Status != -404);
            var total = query.RowCount();

            if (total <= pageSize)
                pageIndex = 0;

            var items = query.Skip(pageIndex * pageSize).Take(pageSize).List().
                Select(x => new MenuShortDetailModel
                {
                    Id = x.Id,
                    Name = x.Title,
                    IsDisable = x.Status == 1 ? true : false
                }).ToList();

            return new PagedList<MenuShortDetailModel>(items, pageIndex, pageSize, total);
        }

        public IPagedList<MenuShortDetailModel> GetSubMenuList(int pageIndex, int pageSize)
        {
            var query = _session.QueryOver<ProductServices>().Where(x => x.Status != -404 );
            var total = query.RowCount();

            if (total <= pageSize)
                pageIndex = 0;

            var items = query.Skip(pageIndex * pageSize).Take(pageSize).List().
                Select(x => new MenuShortDetailModel
                {
                    Id = x.Id,
                    Name = x.Title,
                    IsDisable = x.Status == 0 ? false : true
                }).ToList();

            return new PagedList<MenuShortDetailModel>(items, pageIndex, pageSize, total);
        }
    }
}
