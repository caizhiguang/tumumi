select * from m_message

insert into m_message (senderid,recieverid,title,content,createtime,isread,mtype)
values
(1,2,'����֪ͨ','����֪ͨ���ϵ��˷Ѽ��ָ�',getdate(),0,2)

SELECT [Mid] , [SenderId] , [RecieverId] , [Title] , [Content] , [CreateTime] , [IsRead] , [Mtype] , [RefId] , [SendDeleteFlag] , [RecieveDeleteFlag] FROM (SELECT * FROM [M_Message] 
WHERE [RecieverId] = 2 AND [Mtype] = 2 ) t