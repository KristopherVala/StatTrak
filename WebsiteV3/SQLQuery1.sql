 ALTER TABLE GameDatas DROP DF__GameDatas__Uploa__6E01572D;

alter table GameDatas drop column UploadedTime;


alter table GameDatas add UploadDate nvarchar(50);
