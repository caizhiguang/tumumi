/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2011-1-2 22:37:16                            */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('D_Comment')
            and   type = 'U')
   drop table D_Comment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('D_DocInfo')
            and   type = 'U')
   drop table D_DocInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('D_FileInfo')
            and   type = 'U')
   drop table D_FileInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('D_Rel_DocTag')
            and   type = 'U')
   drop table D_Rel_DocTag
go

if exists (select 1
            from  sysobjects
           where  id = object_id('D_Tag')
            and   type = 'U')
   drop table D_Tag
go

if exists (select 1
            from  sysobjects
           where  id = object_id('M_Bill')
            and   type = 'U')
   drop table M_Bill
go

if exists (select 1
            from  sysobjects
           where  id = object_id('M_Catalog')
            and   type = 'U')
   drop table M_Catalog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('M_Favorite')
            and   type = 'U')
   drop table M_Favorite
go

if exists (select 1
            from  sysobjects
           where  id = object_id('M_Message')
            and   type = 'U')
   drop table M_Message
go

if exists (select 1
            from  sysobjects
           where  id = object_id('M_Purchase')
            and   type = 'U')
   drop table M_Purchase
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ManageUser')
            and   type = 'U')
   drop table ManageUser
go

if exists (select 1
            from  sysobjects
           where  id = object_id('N_News')
            and   type = 'U')
   drop table N_News
go

if exists (select 1
            from  sysobjects
           where  id = object_id('S_Catalog')
            and   type = 'U')
   drop table S_Catalog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('S_Config')
            and   type = 'U')
   drop table S_Config
go

if exists (select 1
            from  sysobjects
           where  id = object_id('S_FriendLink')
            and   type = 'U')
   drop table S_FriendLink
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_JoinDoc')
            and   type = 'U')
   drop table T_JoinDoc
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_ReqDoc')
            and   type = 'U')
   drop table T_ReqDoc
go

if exists (select 1
            from  sysobjects
           where  id = object_id('U_UserInfo')
            and   type = 'U')
   drop table U_UserInfo
go

/*==============================================================*/
/* Table: D_Comment                                             */
/*==============================================================*/
create table D_Comment (
   CommentId            int                  identity,
   DocId                int                  not null,
   Content              varchar(1000)        not null,
   CreateTime           datetime             not null,
   UserId               int                  not null,
   constraint PK_D_COMMENT primary key (CommentId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'D_Comment', 'column', 'CommentId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�ID',
   'user', @CurrentUser, 'table', 'D_Comment', 'column', 'DocId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'D_Comment', 'column', 'Content'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'D_Comment', 'column', 'CreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'D_Comment', 'column', 'UserId'
go

/*==============================================================*/
/* Table: D_DocInfo                                             */
/*==============================================================*/
create table D_DocInfo (
   DocId                int                  identity,
   Title                varchar(100)         not null,
   DocType              int                  not null,
   UserId               int                  not null,
   CateId               int                  null,
   UserCateId           int                  null,
   Description          varchar(2000)        null,
   Tags                 varchar(500)         null,
   Price                decimal              null,
   Length               int                  null,
   ViewCount            int                  null default 0,
   FavCount             int                  null default 0,
   UpCount              int                  null default 0,
   CreateTime           datetime             null default getdate(),
   IsAudit              bit                  null default 0,
   IsRecommend          bit                  null default 0,
   IsTaskDoc            bit                  null default 0,
   constraint PK_D_DOCINFO primary key (DocId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ���',
   'user', @CurrentUser, 'table', 'D_DocInfo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�ID',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'DocId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�����',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'Title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�����doc/pdf..',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'DocType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ������',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'CateId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ļ��б��',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'UserCateId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ����',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ǩ',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'Tags'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۸�',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ���С',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'Length'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'ViewCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ղ���',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'FavCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'UpCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'CreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ͨ�����',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'IsAudit'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ѡ�ĵ�',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'IsRecommend'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ������ĵ�',
   'user', @CurrentUser, 'table', 'D_DocInfo', 'column', 'IsTaskDoc'
go

/*==============================================================*/
/* Table: D_FileInfo                                            */
/*==============================================================*/
create table D_FileInfo (
   Fid                  uniqueidentifier     not null,
   FileType             int                  null,
   FileName             varchar(200)         null,
   OwnerId              int                  not null,
   FilePath             varchar(200)         not null,
   CreateTime           datetime             not null default getdate(),
   constraint PK_D_FILEINFO primary key (Fid)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ���Ϣ��',
   'user', @CurrentUser, 'table', 'D_FileInfo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�ID',
   'user', @CurrentUser, 'table', 'D_FileInfo', 'column', 'Fid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�����',
   'user', @CurrentUser, 'table', 'D_FileInfo', 'column', 'FileType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�ԭʼ����',
   'user', @CurrentUser, 'table', 'D_FileInfo', 'column', 'FileName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ID',
   'user', @CurrentUser, 'table', 'D_FileInfo', 'column', 'OwnerId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�·��',
   'user', @CurrentUser, 'table', 'D_FileInfo', 'column', 'FilePath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'D_FileInfo', 'column', 'CreateTime'
go

/*==============================================================*/
/* Table: D_Rel_DocTag                                          */
/*==============================================================*/
create table D_Rel_DocTag (
   Id                   int                  identity,
   DocId                int                  not null,
   TagId                int                  not null,
   constraint PK_D_REL_DOCTAG primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'D_Rel_DocTag', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�ID',
   'user', @CurrentUser, 'table', 'D_Rel_DocTag', 'column', 'DocId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ǩID',
   'user', @CurrentUser, 'table', 'D_Rel_DocTag', 'column', 'TagId'
go

/*==============================================================*/
/* Table: D_Tag                                                 */
/*==============================================================*/
create table D_Tag (
   TagId                int                  identity,
   Tag                  varchar(20)          not null,
   UseCount             int                  not null default 0,
   constraint PK_D_TAG primary key (TagId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ǩID',
   'user', @CurrentUser, 'table', 'D_Tag', 'column', 'TagId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ǩ����',
   'user', @CurrentUser, 'table', 'D_Tag', 'column', 'Tag'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʹ�ô���',
   'user', @CurrentUser, 'table', 'D_Tag', 'column', 'UseCount'
go

/*==============================================================*/
/* Table: M_Bill                                                */
/*==============================================================*/
create table M_Bill (
   Bid                  int                  identity,
   UserId               int                  not null,
   CreateTime           datetime             not null default getdate(),
   Direct               int                  not null,
   Remark               varchar(500)         not null,
   Status               int                  not null,
   Price                decimal              not null,
   constraint PK_M_BILL primary key (Bid)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˵�',
   'user', @CurrentUser, 'table', 'M_Bill'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˵�ID',
   'user', @CurrentUser, 'table', 'M_Bill', 'column', 'Bid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', @CurrentUser, 'table', 'M_Bill', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'M_Bill', 'column', 'CreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˵�����',
   'user', @CurrentUser, 'table', 'M_Bill', 'column', 'Direct'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˵���ע',
   'user', @CurrentUser, 'table', 'M_Bill', 'column', 'Remark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'M_Bill', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'M_Bill', 'column', 'Price'
go

/*==============================================================*/
/* Table: M_Catalog                                             */
/*==============================================================*/
create table M_Catalog (
   CateId               int                  identity,
   UserId               int                  not null,
   CateText             varchar(50)          not null,
   CreateTime           datetime             not null default getdate(),
   CatalogType          int                  not null,
   constraint PK_M_CATALOG primary key (CateId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ҵ��ĵ�Ŀ¼',
   'user', @CurrentUser, 'table', 'M_Catalog'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'M_Catalog', 'column', 'CateId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', @CurrentUser, 'table', 'M_Catalog', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'M_Catalog', 'column', 'CateText'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'M_Catalog', 'column', 'CreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�������ղط���',
   'user', @CurrentUser, 'table', 'M_Catalog', 'column', 'CatalogType'
go

/*==============================================================*/
/* Table: M_Favorite                                            */
/*==============================================================*/
create table M_Favorite (
   FavId                int                  identity,
   UserId               int                  not null,
   DocId                int                  not null,
   CreateTime           datetime             not null default getdate(),
   FavCateId            int                  null,
   FavCatalog           varchar(50)          null,
   constraint PK_M_FAVORITE primary key (FavId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ҵ��ղ�',
   'user', @CurrentUser, 'table', 'M_Favorite'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ղ�ID',
   'user', @CurrentUser, 'table', 'M_Favorite', 'column', 'FavId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', @CurrentUser, 'table', 'M_Favorite', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�ID',
   'user', @CurrentUser, 'table', 'M_Favorite', 'column', 'DocId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ղ�ʱ��',
   'user', @CurrentUser, 'table', 'M_Favorite', 'column', 'CreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ղط���ID',
   'user', @CurrentUser, 'table', 'M_Favorite', 'column', 'FavCateId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ղط�������',
   'user', @CurrentUser, 'table', 'M_Favorite', 'column', 'FavCatalog'
go

/*==============================================================*/
/* Table: M_Message                                             */
/*==============================================================*/
create table M_Message (
   Mid                  bigint               identity,
   SenderId             int                  null,
   RecieverId           int                  null,
   Title                varchar(200)         null,
   Content              varchar(1000)        null,
   CreateTime           datetime             null,
   IsRead               bit                  null,
   Mtype                int                  not null,
   RefId                int                  null,
   SendDeleteFlag       bit                  null,
   RecieveDeleteFlag    bit                  null,
   constraint PK_M_MESSAGE primary key (Mid)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ��Ϣ��֪ͨ��վ����',
   'user', @CurrentUser, 'table', 'M_Message'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϢID',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'Mid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͷ�ID',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'SenderId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���շ�ID',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'RecieverId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'Title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'Content'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'CreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ��Ķ�',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'IsRead'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ϣ����',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'Mtype'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ظ�ID',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'RefId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ɾ����־',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'SendDeleteFlag'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ռ���ɾ����־',
   'user', @CurrentUser, 'table', 'M_Message', 'column', 'RecieveDeleteFlag'
go

/*==============================================================*/
/* Table: M_Purchase                                            */
/*==============================================================*/
create table M_Purchase (
   Pid                  int                  identity,
   UserId               int                  not null,
   DocId                int                  not null,
   Title                varchar(200)         null,
   PurchaseTime         datetime             null,
   Price                decimal              null,
   Saler                varchar(50)          null,
   constraint PK_M_PURCHASE primary key (Pid)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ҵĹ���',
   'user', @CurrentUser, 'table', 'M_Purchase'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'M_Purchase', 'column', 'Pid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', @CurrentUser, 'table', 'M_Purchase', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�ID',
   'user', @CurrentUser, 'table', 'M_Purchase', 'column', 'DocId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ĵ�����',
   'user', @CurrentUser, 'table', 'M_Purchase', 'column', 'Title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'M_Purchase', 'column', 'PurchaseTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ѽ��',
   'user', @CurrentUser, 'table', 'M_Purchase', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ���',
   'user', @CurrentUser, 'table', 'M_Purchase', 'column', 'Saler'
go

/*==============================================================*/
/* Table: ManageUser                                            */
/*==============================================================*/
create table ManageUser (
   UserName             varchar(20)          not null,
   Password             varchar(100)         not null,
   TrueName             varchar(50)          null,
   Mobile               char(11)             null,
   Level                int                  null,
   CreateTime           datetime             null,
   UpdateTime           datetime             null,
   Remark               varchar(500)         null,
   constraint PK_MANAGEUSER primary key (UserName)
)
go

/*==============================================================*/
/* Table: N_News                                                */
/*==============================================================*/
create table N_News (
   Nid                  int                  identity,
   Title                varchar(200)         null,
   Content              text                 null,
   Catalog              varchar(50)          null,
   constraint PK_N_NEWS primary key (Nid)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ű�',
   'user', @CurrentUser, 'table', 'N_News'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'N_News', 'column', 'Nid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'N_News', 'column', 'Title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'N_News', 'column', 'Content'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ŷ���',
   'user', @CurrentUser, 'table', 'N_News', 'column', 'Catalog'
go

/*==============================================================*/
/* Table: S_Catalog                                             */
/*==============================================================*/
create table S_Catalog (
   CatalogId            int                  identity,
   CatalogName          varchar(50)          not null,
   Pid                  int                  null,
   OrderId              int                  not null default 0,
   constraint PK_S_CATALOG primary key (CatalogId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ����',
   'user', @CurrentUser, 'table', 'S_Catalog'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'S_Catalog', 'column', 'CatalogId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'S_Catalog', 'column', 'CatalogName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ID',
   'user', @CurrentUser, 'table', 'S_Catalog', 'column', 'Pid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'S_Catalog', 'column', 'OrderId'
go

/*==============================================================*/
/* Table: S_Config                                              */
/*==============================================================*/
create table S_Config (
   Id                   int                  not null,
   WebName              varchar(100)         null,
   Keywords             varchar(1000)        null,
   Description          varchar(4000)        null,
   constraint PK_S_CONFIG primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ϵͳȫ������',
   'user', @CurrentUser, 'table', 'S_Config'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'S_Config', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��վ����',
   'user', @CurrentUser, 'table', 'S_Config', 'column', 'WebName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'SEO�ؼ���',
   'user', @CurrentUser, 'table', 'S_Config', 'column', 'Keywords'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'SEO����',
   'user', @CurrentUser, 'table', 'S_Config', 'column', 'Description'
go

/*==============================================================*/
/* Table: S_FriendLink                                          */
/*==============================================================*/
create table S_FriendLink (
   Fid                  int                  identity,
   Title                varchar(200)         not null,
   LinkUrl              varchar(500)         not null,
   OrderId              int                  not null default 0,
   constraint PK_S_FRIENDLINK primary key (Fid)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'S_FriendLink'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ID',
   'user', @CurrentUser, 'table', 'S_FriendLink', 'column', 'Fid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʾ�ı�',
   'user', @CurrentUser, 'table', 'S_FriendLink', 'column', 'Title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ӵ�ַ',
   'user', @CurrentUser, 'table', 'S_FriendLink', 'column', 'LinkUrl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'S_FriendLink', 'column', 'OrderId'
go

/*==============================================================*/
/* Table: T_JoinDoc                                             */
/*==============================================================*/
create table T_JoinDoc (
   JoinId               int                  identity,
   TId                  int                  not null,
   UserId               int                  not null,
   Title                varchar(200)         null,
   DocId                int                  not null,
   constraint PK_T_JOINDOC primary key (JoinId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ͷ��',
   'user', @CurrentUser, 'table', 'T_JoinDoc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ͷ��ID',
   'user', @CurrentUser, 'table', 'T_JoinDoc', 'column', 'JoinId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ID',
   'user', @CurrentUser, 'table', 'T_JoinDoc', 'column', 'TId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ͷ����',
   'user', @CurrentUser, 'table', 'T_JoinDoc', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ͷ�����',
   'user', @CurrentUser, 'table', 'T_JoinDoc', 'column', 'Title'
go

/*==============================================================*/
/* Table: T_ReqDoc                                              */
/*==============================================================*/
create table T_ReqDoc (
   TId                  int                  identity,
   UserId               int                  not null,
   Title                varchar(200)         not null,
   Description          varchar(1000)        not null,
   Price                decimal              not null,
   CreateTime           datetime             not null default getdate(),
   EndTime              datetime             not null,
   Status               int                  not null,
   constraint PK_T_REQDOC primary key (TId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'TId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͱ���',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'Title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͽ��',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'CreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ֹʱ��',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'EndTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'T_ReqDoc', 'column', 'Status'
go

/*==============================================================*/
/* Table: U_UserInfo                                            */
/*==============================================================*/
create table U_UserInfo (
   UserId               int                  identity,
   NickName             varchar(50)          null,
   Email                varchar(50)          not null,
   Password             varchar(100)         not null,
   TrueName             varchar(20)          null,
   Sex                  bit                  null,
   Birthday             datetime             null,
   JobTitle             varchar(100)         null,
   CompanyType          int                  null,
   Major                int                  null,
   RegTime              datetime             not null,
   RegIp                char(15)             null,
   HeadIcon             varchar(100)         null,
   IsStop               bit                  not null default 0,
   constraint PK_U_USERINFO primary key (UserId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ǳ�',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'NickName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'Email'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'Password'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'TrueName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ա�',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'Sex'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'Birthday'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ְҵ',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'JobTitle'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ���',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'CompanyType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'רҵ����',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'Major'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ע��ʱ��',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'RegTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ע��IP',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'RegIp'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͷ��',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'HeadIcon'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ͣ��',
   'user', @CurrentUser, 'table', 'U_UserInfo', 'column', 'IsStop'
go

