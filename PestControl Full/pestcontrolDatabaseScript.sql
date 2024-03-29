USE [PestControl]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VersionNumber] [int] NULL,
	[BusinessId] [nvarchar](255) NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[IsLocked] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Role_Id] [nvarchar](128) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardTypes]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BusinessId] [nvarchar](255) NULL,
	[VersionNumber] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_CardTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BusinessId] [nvarchar](255) NULL,
	[VersionNumber] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[ContactStatus] [int] NOT NULL,
	[Email] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[ZipCode] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
	[Message] [nvarchar](max) NULL,
	[Schedual] [datetime] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VersionNumber] [int] NULL,
	[BusinessId] [nvarchar](255) NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GalleryImages]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GalleryImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VersionNumber] [int] NULL,
	[BusinessId] [nvarchar](255) NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ImageUrl] [varchar](max) NULL,
	[Name] [varchar](50) NULL,
	[Gallery_id] [bigint] NULL,
	[ThumbUrl] [varchar](max) NULL,
 CONSTRAINT [PK__GalleryI__3214EC07145C0A3F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VersionNumber] [int] NULL,
	[BusinessId] [nvarchar](255) NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[ShortDescription] [nvarchar](255) NULL,
	[FriendlyUrl] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BusinessId] [nvarchar](255) NULL,
	[VersionNumber] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Email] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[CardNo] [nvarchar](255) NULL,
	[SecurityCode] [nvarchar](255) NULL,
	[ExpireDate] [datetime] NOT NULL,
	[Amount] [float] NULL,
	[InvoiceNo] [bigint] NULL,
	[Address] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[ZipCode] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
	[Message] [nvarchar](255) NULL,
	[CardType_Id] [bigint] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductServices]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductServices](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VersionNumber] [int] NULL,
	[BusinessId] [nvarchar](255) NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[Title] [nvarchar](255) NULL,
	[ShortDescription] [nvarchar](255) NULL,
	[ServiceDescription] [nvarchar](255) NULL,
	[FriendlyUrl] [nvarchar](255) NULL,
	[Menu_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServiceImages]    Script Date: 2/21/2015 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VersionNumber] [int] NULL,
	[BusinessId] [nvarchar](255) NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ImageUrl] [nvarchar](255) NULL,
	[ThumbUrl] [nvarchar](255) NULL,
	[Menu_id] [bigint] NULL,
	[SubMenuService_id] [bigint] NULL,
	[ProductServices_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201502191037447_InitialCreate', N'ASPNetMVCExtendingIdentity2Roles.Context.ApplicationDbContext', 0x1F8B0800000000000400ED5DDB6EE4B8117D0F907F10F4B41B78BB7DC90C2646F72E3C6D7B63647CC1B4679037832DB1DBC24854AF44796D04F9B23CE493F20B21254AA27891A84BDF26C10203B7543A2C160FC92259ACFDCFBFFE3DF9E535F0AD1718C55E88A6F6C9E8D8B6207242D743ABA99DE0E54F1FEC5F7EFEE31F26576EF06A7DCDE5CEA81CF912C553FB19E3F5F9781C3BCF3000F128F09C288CC3251E396130066E383E3D3EFECBF8E4640C09844DB02C6BF23941D80B60FA83FC9C85C8816B9C00FF3674A11FB3E7E4CD3C45B5EE4000E33570E0D4BE983FDC417CFB7576F58A21A27ADEB890A0E1B7D3CFA10FE31101C3F015DBD685EF01A2DF1CFA4BDB0208851860A2FDF99718CE7114A2D57C4D1E00FFF16D0D89DC12F83164B53A2FC54D2B787C4A2B382E3FCCA19C24C661D012F0E48C596C2C7EDEC9EE76615162D3ABD45AB4D6A95D8949D76BDF7352746A42DB12CB3C9FF9119537B07ED6802301F2C86AFAF0A82017E120FDEFC89A253E4E22384530C111F08FAC87644140FF06DF1EC36F104D51E2FBB6F511C430D38D36F428474D2BC2D59AD4FB210AD730C26FACD6973076226F9DD99421E08828665BB7E0F513442BFC3CB5C99FB675EDBD42377FC278F20579A49B908F7094909F63DEC2E3D2C4B586CF95258C8C9A2C7F5BB4EF45BC26A62C6A3ACA60AF2302F97B187D1B89A84796F1B7652B9C9AB6C2D9C96279F6E1DD7BE09EBDFF333C7B27189DC8551E70EDF0192E991DA8A6376ED5881A515A2159743216CB115B3B2F42DBD027A71F8C1AFA8EB00E2C7C58BC1FD7969BEBBBD9728D19C7F54B13D275E8EE25EBB6DDE58B0A551BE40EBC78AB543545D3D8D667E8A72FE3676FCD0015B579CA84AFA330A07F290D99CA3CCDC3247288E863D820F808A215C43D478EE1478DC31831BA0C01BBE8FEF4DF9A524FDFBD1FA4542DC729E56225C9F9F67E626225BDE5B712B11522BD282D74940D0C4B9B1B92BE63065F05C0F307A0B04129C4735F7A51008B5A7E0C49A300D45AE70710C7647072FF0AE2E7817D3BB9B03974928830688E41B0DE78690FCF21827749B0A03D647B650DD6348FBF87D7C0C1617485E857BDF13E85CEB730C157C8BD04187EC14E0E487F3E7A8139C020EA5C380E8CE36B4266E8CE42B2CACD016F103E3B6D0D4747AD5D4F21331F78817A0E11C6D7A75C54EB2631892627291753CD2775AA7E0A571E32533517D5AB9A4934AACAC4DAAA9A4E37469A3249BDA2A940A39E99545B357397D54C554E5AAF6E21D4A872293988AF4CE152620DBFCC4E61BF77AF59378471669C93811DFE0A118CC8E8EB3E008C6184CA163019EE76E1E3A4CD470BDDF8949A96F415F8C9D04575EA0DE9D8357C6F4861F7BF37A46A92C72F9E4B9D2983CDA75C98C01BC9ABF7B59AFB9CA0D9B6BB43A59ADB2E7C3B6380AEBB5CC471E878692FD0EF983D29769988036A99EE0C955B57CAEDB85BC27D8F3E27FA4DED3F490633282A9F2FD545A98A391E8D4E441371C6A8B791622F41A772DDC68266175FD0F4C4163BDE3DBA843EC4D0BA70B2039619881DE0CA54238DEEB6504C614579C7BEA9B5C8680023FA11A0EBDB988C661EC2F2D0E121C75B03BFD14AC29786D33CAD7B5186F8E612AE21A205365AC2A470F5063D55A028476894260BB520A2664162D87FA4D589B6A36E89930DCB220D2F998FBB1162D65B6C0BE4AC37898902DAC3A65D10942D434D0920AE49F78DA0C262584350E6766E85A0558BED80A055931C1C41B3E5BC69FB0BEBFA7DA367753361FBD37AADB976C0CD8A3D0E8E9AE56E9369FB2BB69E8C292A3BC88645D5FBE2868CD39A295BC6D09827625818C9A6BA5C140151D23A9F14CE96FA315B3589D5A3E0738835F12AB16D95CB286D57926C56056D0232026107981288D4A80D38921FD55445E66CB580CD779E6B61D91429C0721C28B1F5D10A9C78536483D89F5B2C678BBA2AF9218D142D56AF1CB212ADD229889881B154A7DEB2999AD6B3A62BDAA60A982E40DB98B8835174C7388DFC51AEAFDAACB0B88AB1C630E78BB81AD21829AFCCE056CAFB71B395544E7E1B37BF979504975C63A5BC32835B8971B4D9488A99BC85ABD9CB44D5797ACB9D8DC36E3692C6E569E9F4F43296ECD80C64B07C4BB6F0658A7793711606CE1E4CC69A78F1C92D58AF3DB4E2E2C7D9136B9E058FCF7E9AB78F9F0E328CB153B1BAE8791525E130022B28BC2545134DAFBD28C697008305A01BD2333790C4949E9BC6B9C88BE4FD28B921732F2397A67F332A1A86D24B7BC7F25281815F93AA0774BD911E042A88A1FEDCA281FEC00791E2EC7116FA4980F4CB1FFDD795006F1EA6F24289472AEE7AE9D2233DAB5384C857F03C8A177808905AAB102763C13ED2F2496AA636ED7813D3BFEF973F183728DF1C3F1E4873667130FCF7D993AD9BBB9395F7CFC812C7AB0BAEAD123C7F5F0E6A46439E3CDD6CA7DBE4E5F5E93AEA68F5BA96CD375FF896D16DC8E851F2F3191E457766B33F5D49B563F2BDDBBE611E2A3758F6692EEADC97FE279B53DE2C3B846157B723327C3FEF408A4684CD78272C4C9E07608F5A627091D61218F7CE1CB51A0CCF6356DF98230A11EF3CA4F0AA85967C5C7B4549FE45273C8D45D512E625C891EC3CBAFCD61C5911D3CE432B5E77C056E82CBE33475584BDF3C08AD7E6D8B417CBBE7FF9746F8645C5AEE3C667CEECF8A1DFD4A9C1D8CC3839CCCCCB05ECF240DCE396582C24570263CFF79263DA6DE58139969D45F5E39806433F4A550260AB83546DD4AE1EB312D55A9908EAA27AF578ED98BC69BE54B755ABA4D19F100EB31263606DDD73BAC92CCE230D4782B2598D86A814421DB7C0E9D0433D6D08C710CCE9BDF6A8AD65B926B98969C874112E6D60407137BF2F33F9C390FED4E4D186E7A67CAED2919C22EEF03C95CF6CBE5BA2361BB399B3D2419428528CE5C5819470F034618740CDD98CA453A14CC4B6F249892CA9DE620C83111518CD7FF367BE07A9039D0BDC02E42D618CB37B31F6E9F1F10721F5D1FEA4211AC7B1EB2B0ED174892DAA0DB7852B6EE80544CE3388E40B273DF23E94A05200D60D72E1EBD4FE47FAD5797AE24AFF4A1F1F119E7F41DE6F0979F11825D0FAA77CEFB7A5568A9447B9723F04E0F5471ED0E4369BB041D5CB86DD9326756089368E71530987CC3970F3F7A7ECD323EB3E22FDFBDC3A165ABE0B1FF35A74D026FB74506D86E48DBAAE4F3D2AFB645E5B934EA29A923A6826C37457B2734E96C31D902B694C94A8C280DA3D6BC9C2C383642CE935342BB392F44254641E190A6F1013EA328B74C1D2661571C94F9C66156957597596912EAA69338C78A83D58B98BDA7644CABF1CC655E991CB61EB43526AE7C64407BD6E3DEFDA5B90F221F4EAE872CE8316703DF21A7460C681A504186C7654DCF81F0C7B97D4DEE035FF6AB494E1DDF5864B447238C06EAF9E6FF3B6794D1C887A51A6D928DBC245B48EE90EF625C3C1FFD965C0AEBDB9E5D82E85C11E5CBA55DC8EDB7DA2826D734D772EBFE7576ADBA523D833B2B13B93BB4F3AB06DB2E90EE8F79C6C8A88ED83E1DAAEE6CF1D33CD780ADD2BA269AE070C43B60370E90F85346627E183134838EDCD772DA4FB7A6213B36002D5C165533683EC94776ABB8B9010225BBE664912D5B726758595C4D116588AE80BD55FD7140B963A8354AE24515F6CBBBA328FB1B6B24CA6BE58CDADF0BAB29903515B3693A92F5B73D77A17C91D54A495EF9E99642D1099A88EB2D9FB040E876184ED256CA8D4A421994AD32AB036FCF890F2330C6294CA70A289973D9C740C839864175D879BFA36927E61EF0CD322CD821CC546BC2CEEFFDC47BCBED85B951034440F41A7E25F1532376819E62E9FA0512E221C1CDC420C5CE27C5D44D85B020793D7F4E833CD07CCEECF5D050BE8DEA0FB04AF134CAA0C83855F3987A1EE625DF9692E89AACE93FB34402A1EA20A444D8F1E19DFA38F89E7BB85DED78AA30A0D04F543D941236D4B4C0F1C576F05D25D880C8198F90AF7F911066B9F80C5F7680E5E6017DD08FD3EC11570DECA83291D48734354CD3EB9F4C02A0241CC30CAEFC94FC2613778FDF9BFCF1433F2C0720000, N'6.1.0-30225')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'1d892559-18a3-4803-90c7-63be1a9bcaa4', N'CanEdit', N'Edit existing records', N'ApplicationRole')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'84d2b175-017b-44bb-9166-229c6898de3a', N'Admin', N'Global Access', N'ApplicationRole')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'a4044abd-95f0-4079-8676-50950309081a', N'User', N'Restricted to business domain activity', N'ApplicationRole')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [Discriminator], [Role_Id], [ApplicationUser_Id]) VALUES (N'14d9f597-5661-4c1f-be67-e240710746b6', N'1d892559-18a3-4803-90c7-63be1a9bcaa4', N'IdentityUserRole', NULL, NULL)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [Discriminator], [Role_Id], [ApplicationUser_Id]) VALUES (N'14d9f597-5661-4c1f-be67-e240710746b6', N'84d2b175-017b-44bb-9166-229c6898de3a', N'IdentityUserRole', NULL, NULL)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [Discriminator], [Role_Id], [ApplicationUser_Id]) VALUES (N'14d9f597-5661-4c1f-be67-e240710746b6', N'a4044abd-95f0-4079-8676-50950309081a', N'IdentityUserRole', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'14d9f597-5661-4c1f-be67-e240710746b6', N'youremail@testemail.com', 0, N'ABkYFwkOoPSjowyHwcvzd6pEfNnXzItiP4/XxnUeZammGWTLsEewKhu8wGX5++VdKw==', N'13ce7e90-fc9f-4370-8feb-88fb3e04bab4', NULL, 0, 0, NULL, 0, 0, N'youremail@testemail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'28014d9a-10f7-448a-bd78-57c4852901b0', N'demo@gmail.com', 0, N'AMjwyNUE9vNP2PrkJLf/3ypWcShpbGm0GzgynormWHR/X1sdcwm4TseDKYtR1bvpZg==', N'2e4fcea6-7999-447b-b6c1-7c1e1b745e9f', NULL, 0, 0, NULL, 0, 0, N'demo@gmail.com')
SET IDENTITY_INSERT [dbo].[CardTypes] ON 

INSERT [dbo].[CardTypes] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Name]) VALUES (2, NULL, 1, CAST(0x0000A44600276654 AS DateTime), CAST(0x0000A44600276654 AS DateTime), 1, N'Amex')
INSERT [dbo].[CardTypes] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Name]) VALUES (3, NULL, 1, CAST(0x0000A44600276654 AS DateTime), CAST(0x0000A44600276654 AS DateTime), 1, N'Visa')
INSERT [dbo].[CardTypes] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Name]) VALUES (4, NULL, 1, CAST(0x0000A44600276654 AS DateTime), CAST(0x0000A44600276654 AS DateTime), 1, N'MasterCard')
INSERT [dbo].[CardTypes] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Name]) VALUES (5, NULL, 1, CAST(0x0000A44600276654 AS DateTime), CAST(0x0000A44600276654 AS DateTime), 1, N'Discover')
SET IDENTITY_INSERT [dbo].[CardTypes] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [ContactStatus], [Email], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [Phone], [Message]) VALUES (1, NULL, 1, CAST(0x0000A44600A873D4 AS DateTime), CAST(0x0000A44600A873D4 AS DateTime), 0, N'taskin0850@gmail.com', N'Taskin', N'Khaleq', N'asdasd', N'asdasd', N'asdasd', N'1231', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[Gallery] ON 

INSERT [dbo].[Gallery] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [Name]) VALUES (2, 1, NULL, CAST(0x0000A44401585470 AS DateTime), CAST(0x0000A445002FB2F0 AS DateTime), 0, 0, 0, N'Demo Gallery One')
INSERT [dbo].[Gallery] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [Name]) VALUES (3, 1, NULL, CAST(0x0000A44401586AB4 AS DateTime), CAST(0x0000A445002FC934 AS DateTime), 0, 0, 0, N'Demo Gallery Two')
INSERT [dbo].[Gallery] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [Name]) VALUES (4, 6, NULL, CAST(0x0000A445014FD1EC AS DateTime), CAST(0x0000A446002768AC AS DateTime), 1, 0, 0, N'Demo Gallery One')
INSERT [dbo].[Gallery] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [Name]) VALUES (5, 8, NULL, CAST(0x0000A445015052D4 AS DateTime), CAST(0x0000A4460027E994 AS DateTime), 1, 0, 0, N'Demo Gallery Two')
SET IDENTITY_INSERT [dbo].[Gallery] OFF
SET IDENTITY_INSERT [dbo].[GalleryImages] ON 

INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (47, 1, NULL, CAST(0x0000A44600276654 AS DateTime), CAST(0x0000A44600276654 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\lawncare_01.jpg', NULL, 4, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\lawncare_01.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (48, 1, NULL, CAST(0x0000A44600276780 AS DateTime), CAST(0x0000A44600276780 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\lawncare_02.jpg', NULL, 4, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\lawncare_02.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (49, 1, NULL, CAST(0x0000A44600276780 AS DateTime), CAST(0x0000A44600276780 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\lawncare_03.jpg', NULL, 4, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\lawncare_03.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (50, 1, NULL, CAST(0x0000A44600276780 AS DateTime), CAST(0x0000A44600276780 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\lawncare_04.jpg', NULL, 4, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\lawncare_04.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (51, 1, NULL, CAST(0x0000A446002768AC AS DateTime), CAST(0x0000A446002768AC AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\lawncare_05.jpg', NULL, 4, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\lawncare_05.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (52, 1, NULL, CAST(0x0000A4460027E73C AS DateTime), CAST(0x0000A4460027E73C AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\bismark_palm.jpg', NULL, 5, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\bismark_palm.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (53, 1, NULL, CAST(0x0000A4460027E868 AS DateTime), CAST(0x0000A4460027E868 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\cabbage_palm.jpg', NULL, 5, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\cabbage_palm.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (54, 1, NULL, CAST(0x0000A4460027E868 AS DateTime), CAST(0x0000A4460027E868 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\canary_island.jpg', NULL, 5, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\canary_island.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (55, 1, NULL, CAST(0x0000A4460027E868 AS DateTime), CAST(0x0000A4460027E868 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\dade_palm.jpg', NULL, 5, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\dade_palm.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (56, 1, NULL, CAST(0x0000A4460027E994 AS DateTime), CAST(0x0000A4460027E994 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\dwarf_palmetto.jpg', NULL, 5, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\dwarf_palmetto.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (57, 1, NULL, CAST(0x0000A4460027E994 AS DateTime), CAST(0x0000A4460027E994 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\foxtail_palm.jpg', NULL, 5, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\foxtail_palm.jpg')
INSERT [dbo].[GalleryImages] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [ImageUrl], [Name], [Gallery_id], [ThumbUrl]) VALUES (58, 1, NULL, CAST(0x0000A4460027E994 AS DateTime), CAST(0x0000A4460027E994 AS DateTime), 0, 0, 0, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\GalleryImages\manila_palm.jpg', NULL, 5, N'D:\PROJECTS\PestControl 21.02.15\ASPNetMVCExtendingIdentity2Roles\Images\Thumb\manila_palm.jpg')
SET IDENTITY_INSERT [dbo].[GalleryImages] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [VersionNumber], [BusinessId], [CreationDate], [ModificationDate], [Status], [CreateBy], [ModifiedBy], [Title], [Description], [ShortDescription], [FriendlyUrl]) VALUES (1, 3, NULL, CAST(0x0000A4460026C49C AS DateTime), CAST(0x0000A4460026C49C AS DateTime), 1, 0, 0, N'Pest Control', N'test description.', N'Test description', N'pest-control')
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Email], [FirstName], [LastName], [CardNo], [SecurityCode], [ExpireDate], [Amount], [InvoiceNo], [Address], [City], [State], [ZipCode], [Phone], [Message], [CardType_Id]) VALUES (1, NULL, 1, CAST(0x0000A4460071F958 AS DateTime), CAST(0x0000A44600D4D9D8 AS DateTime), 0, N'now@gmail.com', N'asdasdkl;', N'kaskdkasldk', NULL, N'123', CAST(0x0000A56200000000 AS DateTime), 5, 5, N'asdashdjk', N'askhdasjkh', N'aaksdh', N'234', N'1321321321', N'asdlaskdjklj', 3)
INSERT [dbo].[Payments] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Email], [FirstName], [LastName], [CardNo], [SecurityCode], [ExpireDate], [Amount], [InvoiceNo], [Address], [City], [State], [ZipCode], [Phone], [Message], [CardType_Id]) VALUES (2, NULL, 1, CAST(0x0000A446007E6E04 AS DateTime), CAST(0x0000A44600E14E84 AS DateTime), 0, N'taskin0850@gmail.com', N'Taskin', N'Khaleq', NULL, N'123', CAST(0x0000A56200000000 AS DateTime), 5, 5, N'asdashdjk', N'askhdasjkh', N'aaksdh', N'234', N'1321321321', N'asdlaskdjklj', 3)
INSERT [dbo].[Payments] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Email], [FirstName], [LastName], [CardNo], [SecurityCode], [ExpireDate], [Amount], [InvoiceNo], [Address], [City], [State], [ZipCode], [Phone], [Message], [CardType_Id]) VALUES (3, NULL, 1, CAST(0x0000A446007F4A54 AS DateTime), CAST(0x0000A44600E22C00 AS DateTime), 0, N'taskin0850@gmail.com', N'Taskin', N'Khaleq', NULL, N'123', CAST(0x0000A56200000000 AS DateTime), 5, 5, N'asdashdjk', N'askhdasjkh', N'aaksdh', N'234', N'1321321321', N'asdlaskdjklj', 3)
INSERT [dbo].[Payments] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Email], [FirstName], [LastName], [CardNo], [SecurityCode], [ExpireDate], [Amount], [InvoiceNo], [Address], [City], [State], [ZipCode], [Phone], [Message], [CardType_Id]) VALUES (4, NULL, 1, CAST(0x0000A4460098961C AS DateTime), CAST(0x0000A44600FB769C AS DateTime), 0, N'taskin0850@gmail.com', N'Taskin', N'Khaleq', N'4111111111111111', N'123', CAST(0x0000A56200000000 AS DateTime), 5, 5, N'asdasd', N'asdasd', N'asdasd', N'1231', N'123121231', N'asdasdasdasdasd', 4)
INSERT [dbo].[Payments] ([Id], [BusinessId], [VersionNumber], [CreationDate], [ModificationDate], [Status], [Email], [FirstName], [LastName], [CardNo], [SecurityCode], [ExpireDate], [Amount], [InvoiceNo], [Address], [City], [State], [ZipCode], [Phone], [Message], [CardType_Id]) VALUES (5, NULL, 1, CAST(0x0000A44600997398 AS DateTime), CAST(0x0000A44600FC5418 AS DateTime), 0, N'taskin0850@gmail.com', N'Taskin', N'Khaleq', N'4111111111111111', N'123', CAST(0x0000A56200000000 AS DateTime), 5, 5, N'asdasd', N'asdasd', N'asdasd', N'1231', N'123121231', N'asdasdasdasdasd', 4)
SET IDENTITY_INSERT [dbo].[Payments] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_Role_Id] FOREIGN KEY([Role_Id])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_Role_Id]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CardTypes]  WITH CHECK ADD  CONSTRAINT [FK_CardTypes_CardTypes] FOREIGN KEY([Id])
REFERENCES [dbo].[CardTypes] ([Id])
GO
ALTER TABLE [dbo].[CardTypes] CHECK CONSTRAINT [FK_CardTypes_CardTypes]
GO
ALTER TABLE [dbo].[GalleryImages]  WITH CHECK ADD  CONSTRAINT [FK8F104A4F9E471304] FOREIGN KEY([Gallery_id])
REFERENCES [dbo].[Gallery] ([Id])
GO
ALTER TABLE [dbo].[GalleryImages] CHECK CONSTRAINT [FK8F104A4F9E471304]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_CardTypes] FOREIGN KEY([CardType_Id])
REFERENCES [dbo].[CardTypes] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_CardTypes]
GO
ALTER TABLE [dbo].[ProductServices]  WITH CHECK ADD  CONSTRAINT [FK1A594F9E86CAD0E3] FOREIGN KEY([Menu_id])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[ProductServices] CHECK CONSTRAINT [FK1A594F9E86CAD0E3]
GO
ALTER TABLE [dbo].[ServiceImages]  WITH CHECK ADD  CONSTRAINT [FK20FDF7E2EBE48DC] FOREIGN KEY([SubMenuService_id])
REFERENCES [dbo].[ProductServices] ([Id])
GO
ALTER TABLE [dbo].[ServiceImages] CHECK CONSTRAINT [FK20FDF7E2EBE48DC]
GO
ALTER TABLE [dbo].[ServiceImages]  WITH CHECK ADD  CONSTRAINT [FK20FDF7E46370B0D] FOREIGN KEY([ProductServices_id])
REFERENCES [dbo].[ProductServices] ([Id])
GO
ALTER TABLE [dbo].[ServiceImages] CHECK CONSTRAINT [FK20FDF7E46370B0D]
GO
ALTER TABLE [dbo].[ServiceImages]  WITH CHECK ADD  CONSTRAINT [FK20FDF7E86CAD0E3] FOREIGN KEY([Menu_id])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[ServiceImages] CHECK CONSTRAINT [FK20FDF7E86CAD0E3]
GO
