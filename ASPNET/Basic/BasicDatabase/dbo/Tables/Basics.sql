Create Table dbo.Basics
(
	Id Int Identity(1, 1) Not Null Primary Key,		-- 번호
	Name NVarChar(25) Not Null,						-- 이름
	Email NVarChar(100) Null,						-- 이메일
	Title NVarChar(150) Not Null,					-- 제목
	PostDate DateTime Default GetDate(),			-- 작성일
	PostIp NVarChar(15) Not Null,					-- 작성 IP
	Content NText Not Null,							-- 내용
	Password NVarChar(20) Not Null,					-- 비밀번호
	ReadCount Int Default 0,						-- 조회수
	Encoding NVarChar(10) Not Null,					-- 인코딩(HTML/Text/Mixed)
	Homepage NVarChar(100) Null,						-- 홈페이지
	ModifyDate SmallDateTime Null,					-- 수정일
	ModifyIp NVarChar(15) Null						-- 수정 IP
)
GO