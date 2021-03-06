USE [QLDSV_TC]
GO
/****** Object:  UserDefinedTableType [dbo].[TYPE_DANGKY]    Script Date: 5/25/2022 10:35:59 PM ******/
CREATE TYPE [dbo].[TYPE_DANGKY] AS TABLE(
	[MALTC] [int] NULL,
	[MASV] [nchar](10) NULL,
	[DIEM_CC] [int] NULL,
	[DIEM_GK] [float] NULL,
	[DIEM_CK] [float] NULL
)
GO
/****** Object:  View [dbo].[NIENKHOA_HOCKY]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NIENKHOA_HOCKY]
AS
SELECT DISTINCT NIENKHOA, HOCKY
FROM            dbo.LOPTINCHI
GO
/****** Object:  View [dbo].[v_DSGIANGVIEN]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_DSGIANGVIEN]
AS
SELECT        TOP (100) PERCENT HO, TEN, MAGV, HO + ' ' + TEN AS HOTEN
FROM            dbo.GIANGVIEN
ORDER BY TEN, HO
GO
/****** Object:  View [dbo].[v_DSLTC]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_DSLTC]
AS
SELECT        dbo.LOPTINCHI.MALTC, dbo.MONHOC.TENMH, dbo.LOPTINCHI.NIENKHOA, dbo.LOPTINCHI.HOCKY, dbo.LOPTINCHI.NHOM, dbo.LOPTINCHI.SOSVTOITHIEU, 
                         dbo.GIANGVIEN.HO + ' ' + dbo.GIANGVIEN.TEN AS TENGIANGVIEN
FROM            dbo.LOPTINCHI INNER JOIN
                         dbo.MONHOC ON dbo.LOPTINCHI.MAMH = dbo.MONHOC.MAMH INNER JOIN
                         dbo.GIANGVIEN ON dbo.LOPTINCHI.MAGV = dbo.GIANGVIEN.MAGV
GO
/****** Object:  View [dbo].[v_DSPHANMANH]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_DSPHANMANH]
as
SELECT TENPM=PUBS.name, TENSERVER= subscriber_server
   FROM dbo.sysmergepublications PUBS,  dbo.sysmergesubscriptions SUBS
   WHERE PUBS.pubid= SUBS.PUBID  AND PUBS.publisher <> SUBS.subscriber_server
GO
/****** Object:  StoredProcedure [dbo].[SP_BDMH]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BDMH]
@MALTC INT
AS
BEGIN 
	SELECT SV.MASV, HOTENSV=HO+' '+TEN, DIEM_CC,DIEM_GK,DIEM_CK
	FROM (SELECT MASV, DIEM_CC, DIEM_GK, DIEM_CK FROM DANGKY WHERE MALTC = @MALTC AND HUYDANGKY ='FALSE') DSDK,
		SINHVIEN SV
	WHERE DSDK.MASV = SV.MASV
END

--------------------------------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SP_BDMHLTC]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BDMHLTC]
@MALTC INT
AS
BEGIN
	DECLARE @TEMP TABLE
	(
		MASV NCHAR(10),
		HOTEN NVARCHAR(50),
		DIEM_CC INT,
		DIEM_GK FLOAT,
		DIEM_CK FLOAT
	)

	INSERT INTO @TEMP 
	EXEC SP_BDMH @MALTC
	SELECT * FROM @TEMP
END
----------------------------------------------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SP_CHECK_LTC]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHECK_LTC]
@NIENKHOA NCHAR(9), @MAMH NCHAR(10), @NHOM INT, @HOCKY INT
AS
BEGIN
	IF EXISTS(SELECT MALTC FROM LOPTINCHI WHERE NIENKHOA = @NIENKHOA AND MAMH = @MAMH AND NHOM = @NHOM AND HOCKY = @HOCKY)
		SELECT KT = 1
	ELSE
		IF EXISTS(SELECT MALTC FROM LINK0.QLDSV_TC.DBO.LOPTINCHI WHERE NIENKHOA = @NIENKHOA AND MAMH = @MAMH AND NHOM = @NHOM AND HOCKY = @HOCKY)
			SELECT KT = 1
		ELSE
			SELECT KT = 0
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CHECKMALOP]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHECKMALOP]
@MLOP NCHAR(10)
AS 
IF EXISTS(SELECT MALOP FROM DBO.LOP WHERE MALOP = @MLOP)
	BEGIN
		SELECT 'SV' = 1 
	END
ELSE
IF EXISTS(SELECT MALOP FROM LINK0.QLDSV_TC.DBO.LOP WHERE MALOP = @MLOP)
	BEGIN
		SELECT 'SV' = 2
	END
ELSE
	SELECT 'SV' = 0
GO
/****** Object:  StoredProcedure [dbo].[SP_CHECKMASINHVIEN]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHECKMASINHVIEN] 
@MSV NCHAR(10)
AS
BEGIN
	IF EXISTS(SELECT MASV FROM DBO.SINHVIEN WHERE MASV = @MSV)
	BEGIN
		SELECT 'SV' = 1 
	END
ELSE
IF EXISTS(SELECT MASV FROM LINK0.QLDSV_TC.DBO.SINHVIEN WHERE MASV = @MSV)
	BEGIN
		SELECT 'SV' = 2
	END
ELSE
	SELECT 'SV' = 0
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CHECKTENLOP]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHECKTENLOP]
@TLOP NVARCHAR(50)
AS 
IF EXISTS(SELECT TENLOP FROM DBO.LOP WHERE TENLOP = @TLOP)
	BEGIN
		SELECT 'SV' = 1 
	END
ELSE
IF EXISTS(SELECT TENLOP FROM LINK0.QLDSV_TC.DBO.LOP WHERE TENLOP = @TLOP)
	BEGIN
		SELECT 'SV' = 2
	END
ELSE
	SELECT 'SV' = 0

GO
/****** Object:  StoredProcedure [dbo].[SP_CHECKTENMH]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHECKTENMH]
@TENMH NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT * FROM MONHOC WHERE TENMH = @TENMH)
		SELECT KT = 1
	ELSE 
		IF EXISTS(SELECT * FROM LINK0.QLDSV_TC.DBO.MONHOC WHERE TENMH = @TENMH)	
			SELECT KT = 1
		ELSE
			SELECT KT = 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CHECKTMAMH]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHECKTMAMH]
@MAMH NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT * FROM MONHOC WHERE MAMH = @MAMH)
		SELECT KT = 1
	ELSE 
		IF EXISTS(SELECT * FROM LINK0.QLDSV_TC.DBO.MONHOC WHERE MAMH = @MAMH)	
			SELECT KT = 1
		ELSE
			SELECT KT = 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DANGKY_LTC]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[SP_DANGKY_LTC]
@MALTC INT, @MASV NCHAR(10)
AS
BEGIN
	IF EXISTS(SELECT * FROM DANGKY WHERE MALTC = @MALTC AND MASV = @MASV)
		BEGIN
			UPDATE DANGKY SET HUYDANGKY = 0 WHERE MALTC = @MALTC AND MASV = @MASV
		END
	ELSE
		BEGIN
			INSERT INTO DANGKY(MALTC,MASV)
			VALUES (@MALTC, @MASV)
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DANGNHAP]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DANGNHAP]
@TENLOGIN NVARCHAR (50)
AS
DECLARE @TENUSER NVARCHAR(50)
SELECT @TENUSER=NAME FROM sys.sysusers WHERE sid = SUSER_SID(@TENLOGIN)
 
 SELECT USERNAME = @TENUSER, 
  HOTEN = (SELECT HO+ ' '+ TEN FROM GIANGVIEN  WHERE MAGV = @TENUSER ),
   ROLENAME=NAME
   FROM sys.sysusers 
   WHERE UID = (SELECT GROUPUID 
                 FROM SYS.SYSMEMBERS 
                   WHERE MEMBERUID= (SELECT UID FROM sys.sysusers 
                                      WHERE NAME=@TENUSER))
GO
/****** Object:  StoredProcedure [dbo].[SP_DSDHP]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DSDHP]
@MALOP NCHAR(10), @NIENKHOA NCHAR(9), @HOCKY INT
AS
BEGIN
	SELECT MASV, HOTEN = HO + TEN
	INTO #B1
	FROM SINHVIEN SV
	WHERE SV.MALOP = @MALOP

	SELECT MASV
	INTO #B2
	FROM SINHVIEN SV
	WHERE SV.MALOP = @MALOP

	SELECT MASV, HOCPHI
	INTO #B3
	FROM HOCPHI HP
	WHERE NIENKHOA = @NIENKHOA AND HOCKY = @HOCKY

	SELECT MASV, SOTIENDONG
	INTO #B4
	FROM CT_DONGHOCPHI CTDHP
	WHERE NIENKHOA = @NIENKHOA AND HOCKY = @HOCKY
	
	SELECT #B2.MASV, #B3.HOCPHI
	INTO #B5
	FROM #B2 INNER JOIN #B3 ON #B2.MASV = #B3.MASV

	SELECT #B2.MASV, #B4.SOTIENDONG 
	INTO #B6
	FROM #B2 INNER JOIN #B4 ON #B2.MASV = #B4.MASV

	SELECT #B5.MASV, #B5.HOCPHI, #B6.SOTIENDONG
	INTO #B7
	FROM #B5 INNER JOIN #B6 ON #B5.MASV = #B6.MASV

	SELECT STT = ROW_NUMBER() OVER (ORDER BY #B1.HOTEN),[HỌ VÀ TÊN] = #B1.HOTEN, [HỌC PHÍ] = #B7.HOCPHI, [SỐ TIỀN ĐÓNG] = #B7.SOTIENDONG
	FROM #B1 INNER JOIN #B7 ON #B1.MASV = #B7.MASV
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DSDK]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Viết SP liệt kê danh sách sinh viên đăng ký lớp tín chỉ dựa vào các tham số :
-- @NIENKHOA, @HOCKY, @MAMH, @NHOM
--Kết xuất : Tên khoa quản lý lớp, Tên MH, MASV, HO, TEN,
CREATE proc [dbo].[sp_DSDK] 
@NIENKHOA NVARCHAR(11), @HOCKY INT,@MAMH NVARCHAR(10), @NHOM INT
as
begin
	DECLARE @MALTC INT
	SELECT @MALTC = MALTC
	FROM LOPTINCHI LTC
	WHERE MAMH = @MAMH AND NIENKHOA = @NIENKHOA AND @NHOM = NHOM AND @HOCKY = HOCKY and HUYLOP = 0

	SELECT MASV
	INTO #B1
	FROM DANGKY DK   
	WHERE DK.MALTC = @MALTC

	SELECT #B1.MASV, SV.HO, SV.TEN, MALOP
	FROM #B1 INNER JOIN SINHVIEN SV ON #B1.MASV = SV.MASV
	ORDER BY SV.TEN, SV.HO
end

GO
/****** Object:  StoredProcedure [dbo].[SP_DSLTC]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DSLTC] 
@MAKHOA NCHAR(50), @NIENKHOA NCHAR(9), @HOCKY INT
AS 
BEGIN

	SELECT MALTC, TENMH, NHOM, HOTEN=HO +' ' + TEN, SOSVDANGKY = (SELECT COUNT(D.MASV) FROM DANGKY D WHERE D.MALTC=LTC.MALTC)
	FROM (SELECT MALTC, MAMH, NHOM, MAGV FROM LOPTINCHI WHERE MAKHOA=@MAKHOA AND NIENKHOA=@NIENKHOA AND HOCKY=@HOCKY AND HUYLOP='FALSE') LTC,
		MONHOC MH, GIANGVIEN GV
	WHERE LTC.MAMH=MH.MAMH AND LTC.MAGV = GV.MAGV
	ORDER BY TENMH, NHOM

END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SP_DSLTC_NIENKHOAHOCKY]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[SP_DSLTC_NIENKHOAHOCKY]
@NK NCHAR(9), @HK INT
AS 

BEGIN
	--SET @SOSVDADK = COUNT(SELECT LOPTINCHI.MALTC FROM LOPTINCHI INNER JOIN DANGKY ON LOPTINCHI.MALTC = DANGKY.MALTC)
	SELECT STT=ROW_NUMBER() OVER(ORDER BY MH.MAMH,NHOM), MH.MAMH, MH.TENMH, NHOM, TENGV=(SELECT HO + ' ' + TEN FROM GIANGVIEN WHERE LOPTINCHI.MAGV = GIANGVIEN.MAGV), SOSVTOITHIEU,SOSVDADK = COUNT(DK.MASV),  LOPTINCHI.MALTC
	FROM LOPTINCHI
	LEFT JOIN (SELECT MAMH, TENMH FROM MONHOC) MH 
	ON LOPTINCHI.MAMH = MH.MAMH
	LEFT JOIN (SELECT MALTC, MASV FROM DANGKY WHERE HUYDANGKY = 0) DK 
	ON DK.MALTC = LOPTINCHI.MALTC
	WHERE LOPTINCHI.NIENKHOA = @NK and LOPTINCHI.HOCKY = @HK and LOPTINCHI.HUYLOP = 0 
	GROUP BY MH.MAMH, MH.TENMH, NHOM,LOPTINCHI.MAGV, SOSVTOITHIEU,LOPTINCHI.MALTC

END

GO
/****** Object:  StoredProcedure [dbo].[SP_DSLTCDADANGKY]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_DSLTCDADANGKY] 
@MSV NCHAR(10) , @NIENKHOA NVARCHAR(11), @HOCKY INT 
AS 

BEGIN
	SELECT ROW_NUMBER() over(ORDER BY MH.TENMH, LTC.NHOM) STT,LTC.MAMH,TENMH,NIENKHOA,HOCKY,NHOM, LTC.MALTC
	FROM (SELECT MALTC FROM DANGKY WHERE MASV = @MSV AND HUYDANGKY = 0) DS
	INNER JOIN (SELECT MALTC,MAMH,NIENKHOA,HOCKY,NHOM FROM LOPTINCHI) LTC 
		ON DS.MALTC = LTC.MALTC
	INNER JOIN (SELECT MAMH,TENMH FROM MONHOC) MH 
		ON LTC.MAMH = MH.MAMH
	WHERE NIENKHOA = @NIENKHOA AND HOCKY = @HOCKY 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DSSVDKLTC]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DSSVDKLTC]
@NIENKHOA NCHAR(9), @HOCKY INT, @MAMH NCHAR(10), @NHOM INT
AS
BEGIN
	DECLARE @MALTC INT
	SELECT @MALTC = MALTC
	FROM LOPTINCHI LTC WITH (INDEX = IX_MAMH_NIENKHOA_NHOM_HOCKY)
	WHERE MAMH = @MAMH AND NIENKHOA = @NIENKHOA AND @NHOM = NHOM AND @HOCKY = HOCKY and HUYLOP = 0

	SELECT MASV
	INTO #B1
	FROM DANGKY DK 
	WHERE DK.MALTC = @MALTC

	SELECT STT=ROW_NUMBER() over (order by #b1.masv),#B1.MASV, SV.HO, SV.TEN, PHAI, MALOP
	FROM #B1 INNER JOIN SINHVIEN SV ON #B1.MASV = SV.MASV
	ORDER BY SV.TEN, SV.HO
END

GO
/****** Object:  StoredProcedure [dbo].[SP_LAY_HOTENSV]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LAY_HOTENSV]
@MASV NCHAR(10)
AS
BEGIN
	SELECT HOTEN = HO + ' ' +  TEN FROM SINHVIEN WHERE MASV = @MASV
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Lay_Thong_Tin_GV_Tu_Login]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Lay_Thong_Tin_GV_Tu_Login]
 @TENLOGIN NVARCHAR(100)
 AS
 DECLARE @UID INT
 DECLARE @MAGV NVARCHAR(100)
 SELECT @UID = uid, @MAGV = name FROM SYS.sysusers
	WHERE sid = SUSER_SID(@TENLOGIN)
 SELECT MAGV = @MAGV,
		HOTEN = (SELECT HO+ ' '+TEN FROM dbo.GIANGVIEN WHERE MAGV=@MAGV),
		TENNHOM= name
		FROM SYS.sysusers
		WHERE uid = (SELECT groupuid FROM SYS.sysmembers WHERE memberuid = @UID)


GO
/****** Object:  StoredProcedure [dbo].[SP_LayThongTinSV_DangNhap]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayThongTinSV_DangNhap]
@masv NCHAR(10),@password NVARCHAR(40)
AS
BEGIN
	SELECT MASV,HOTEN = HO+' '+TEN FROM dbo.SINHVIEN WHERE MASV = @masv AND PASSWORD = @password
END

GO
/****** Object:  StoredProcedure [dbo].[SP_PD]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_PD]
@MASV NCHAR(10)
AS
BEGIN
	SELECT DK.MALTC, DIEM_HM = DIEM_CC*0.1 + DIEM_GK*0.3 + DIEM_CK*0.6
	INTO #B1
	FROM DANGKY DK
	WHERE DK.MASV = @MASV
	
	SELECT DK.MALTC
	INTO #B2
	FROM DANGKY DK
	WHERE DK.MASV = @MASV

	SELECT LTC.MALTC, LTC.MAMH
	INTO #B3
	FROM LOPTINCHI LTC RIGHT JOIN #B2 ON LTC.MALTC = #B2.MALTC AND LTC.HUYLOP = 0
	
	SELECT #B3.MALTC, MH.TENMH
	INTO #B4
	FROM #B3 INNER JOIN MONHOC MH ON MH.MAMH = #B3.MAMH
	
	SELECT #B4.TENMH, DIEM_HM = MAX(#B1.DIEM_HM)
	FROM #B1 INNER JOIN #B4 ON #B1.MALTC = #B4.MALTC
	GROUP BY #B4.TENMH
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PDHOPLE]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_PDHOPLE]
@MASV NCHAR(10)
AS
BEGIN
	DECLARE @TEMP TABLE
	(
		TENMH NVARCHAR(50),
		DIEM_HM FLOAT
	)
	
	INSERT INTO @TEMP EXEC SP_PD @MASV
	SELECT * FROM @TEMP
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TAOLOGIN]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TAOLOGIN]
  @LGNAME VARCHAR(50),
  @PASS VARCHAR(50),
  @USERNAME VARCHAR(50),
  @ROLE VARCHAR(50)
AS
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'QLDSV_TC'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
     RETURN 1
 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RETURN 2
  END
  EXEC sp_addrolemember @ROLE, @USERNAME
  IF @ROLE= 'PGV' OR @ROLE= 'KHOA' OR @ROLE= 'PKT'
  BEGIN 
    EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
    EXEC sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
  END
RETURN 0  -- THANH CONG

GO
/****** Object:  StoredProcedure [dbo].[SP_THONGTINGV]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_THONGTINGV]
 @TENLOGIN NVARCHAR(100)
 AS
 DECLARE @UID INT
 DECLARE @MAGV NVARCHAR(100)
 SELECT @UID = uid, @MAGV = name FROM SYS.sysusers
	WHERE sid = SUSER_SID(@TENLOGIN)
 SELECT MAGV = @MAGV,
		HOTEN = (SELECT HO+ ' '+TEN FROM dbo.GIANGVIEN WHERE MAGV=@MAGV),
		TENNHOM= name
		FROM SYS.sysusers
		WHERE uid = (SELECT groupuid FROM SYS.sysmembers WHERE memberuid = @UID)


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_DIEM]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UPDATE_DIEM] 
	@DIEMTHI TYPE_DANGKY READONLY
AS
BEGIN
	MERGE INTO DANGKY AS Target
	USING (SELECT MALTC, MASV, DIEM_CC, DIEM_GK, DIEM_CK FROM @DIEMTHI ) AS Source
	On Target.MALTC=Source.MALTC AND Target.MASV=Source.MASV
	
	WHEN MATCHED THEN
	UPDATE SET Target.DIEM_CC = Source.DIEM_CC, Target.DIEM_GK=Source.DIEM_GK, Target.DIEM_CK = Source.DIEM_CK
	
	WHEN NOT MATCHED THEN
	INSERT (MALTC, MASV, DIEM_CC, DIEM_GK, DIEM_CK)
		VALUES (Source.MALTC, Source.MASV, Source.DIEM_CC, Source.DIEM_GK, Source.DIEM_CK);
END
GO
/****** Object:  StoredProcedure [dbo].[TIM_SV]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TIM_SV] @MASV NCHAR(10)
AS
BEGIN
	IF EXISTS(SELECT * FROM SINHVIEN WHERE MASV = @MASV)
		RETURN 1
	ELSE 
		RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[Xoa_Login]    Script Date: 5/25/2022 10:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[Xoa_Login]
  @LGNAME VARCHAR(50),
  @USRNAME VARCHAR(50)
  
AS
EXEC SP_DROPUSER @USRNAME
  EXEC SP_DROPLOGIN @LGNAME

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LOPTINCHI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NIENKHOA_HOCKY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NIENKHOA_HOCKY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GIANGVIEN"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DSGIANGVIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DSGIANGVIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[25] 2[17] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LOPTINCHI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MONHOC"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GIANGVIEN"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 2580
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2445
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DSLTC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DSLTC'
GO
