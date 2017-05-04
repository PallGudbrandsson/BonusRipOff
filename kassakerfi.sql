drop database if exists 2410982069_kassakerfi;
create database 2410982069_kassakerfi;
use 2410982069_kassakerfi;

DROP TABLE IF EXISTS vorur;
CREATE TABLE vorur (
ID int,
vorunafn varchar(150),
stk_verd float,
vorunr int,
strikamerki int,
kaelivara bool,
vigtad bool,
instock int
);

DROP TABLE IF EXISTS verslun;
CREATE TABLE verslun (
ID int,
longi float,
lati float,
heimilisfang varchar(40),
opnunardags date,
m2 int,
A_madur int,
B_madur int,
C_madur int
);

DROP TABLE IF EXISTS staff;
CREATE TABLE staff (
kt varchar(11),
nafn varchar(150),
titill varchar(40),
launat int,
kyn bool,
hof_storf date,
verslun_id int,
pass varchar(10)
);

DROP TABLE IF EXISTS afgreidsla;
CREATE TABLE afgreidsla (
ID varchar(40),
kassi int,
verslun_ID int,
dags datetime,
staff_kt varchar(11),
summa float,
afgreidslaTXT longtext,
adstod int
);


DROP TABLE IF EXISTS kaup;
CREATE TABLE kaup (
afgID varchar(40),
varaID int,
magn int,
aflattur float
);

ALTER TABLE vorur ADD CONSTRAINT "vorurPK" PRIMARY KEY ID;
ALTER TABLE staff ADD CONSTRAINT 'staffPK' PRIMARY KEY kt;
ALTER TABLE verslun ADD CONSTRAINT 'verslunPK' PRIMARY KEY ID;
ALTER TABLE kaup ADD CONSTRAINT 'kaupPK' PRIMARY KEY afgID;

ALTER TABLE vorur ADD CONSTRAINT 'vorurAI' AUTO_INCREMENT ID;
ALTER TABLE verslun ADD CONSTRAINT 'verslunAI' AUTO_INCREMENT ID;

ADD CONSTRAINT 'VerslunA_madurFK' verslun(A_madur) FOREIGN KEY REFERENCES staff(kt);
ADD CONSTRAINT 'VerslunB_madurFK' verslun(B_madur) FOREIGN KEY REFERENCES staff(kt);
ADD CONSTRAINT 'VerslunC_madurFK' verslun(C_madur) FOREIGN KEY REFERENCES staff(kt);
ADD CONSTRAINT 'kaupFK' kaup(varaID) FOREIGN KEY REFERENCES vorur(ID);
ADD CONSTRAINT 'afgIDFk' afgreidsla(ID) FOREIGN KEY REFERENCES kaup(afgID);
ADD CONSTRAINT 'afgVerslunFK' afgreidsla(verslun) FOREIGN KEY REFERENCES verslun(ID);
ADD CONSTRAINT 'afgStaffFK' afgreidsla(staff) FOREIGN KEY REFERENCES staff(kt);
ADD CONSTRAINT 'staffVerslunFK' staff(verslun) FOREIGN KEY REFERENCES verslun(ID);

INSERT INTO verslun(long, lat, heimilisfang, opnunardags,m2,A_madur,B_madur,C_madur) VALUES (64.1458419,-21.7568441,"Korputorg", "2010-02-27", 2500, 2308982439,0101900002);

INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun,pass) VALUES (2410982069, "Pall Gudbrandsson", "Bitch", 2,0,"2015-07-31",1,md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun,pass) VALUES (2308982439, "Mani Karl Gudmundsson", "A-madur", 5,0,CURDATE(),1,md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun,pass) VALUES (0604982539, "Inga Kristin", "Kassadama", 0, 1,"2010-02-27", 1,md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun,pass) VALUES (2710560000, "Sigurdur R Ragnarsson", "King", 6,0,"2016-04-28", 1, md5("pass.1234");
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun,pass) VALUES (0101900001, "Random1", "B-madur", 4, CURDATE(), 1, md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun,pass) VALUES (0101900002, "Random2", "C-madur", 3, CURDATE(), 1, md5("pass.123"));