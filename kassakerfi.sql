drop database if exists 2410982069_kassakerfi;
create database 2410982069_kassakerfi;
use 2410982069_kassakerfi;

DROP TABLE IF EXISTS vorur;
CREATE TABLE vorur (
ID int,
vorunafn varchar(150),
stk_verd float,
strikamerki int,
kaelivara bool,
instock int,
CONSTRAINT vorurPK PRIMARY KEY(ID)
);

DROP TABLE IF EXISTS verslun;
CREATE TABLE verslun (
ID int AUTO_INCREMENT,
longi float,
lati float,
heimilisfang varchar(40),
opnunardags date,
m2 int,
A_madur varchar(11),
B_madur varchar(11),
C_madur varchar(11),
CONSTRAINT verslunPK PRIMARY KEY(ID)
);

DROP TABLE IF EXISTS staff;
CREATE TABLE staff (
kt varchar(11),
nafn varchar(150),
titill varchar(40),
launaf int,
kyn bool,
startD date,
verslun_id int,
pass varchar(32),
CONSTRAINT staffPK PRIMARY KEY(kt)
);

DROP TABLE IF EXISTS afgreidsla;
CREATE TABLE afgreidsla (
ID varchar(40),
kassi int,
verslun_ID int,
dags datetime,
staff_kt varchar(11),
summa float
);

DROP TABLE IF EXISTS kvittanir;
CREATE TABLE kvittanir(
	afgID varchar(10),
	kvittun longtext
);


DROP TABLE IF EXISTS kaup;
CREATE TABLE kaup (
afgID varchar(40),
varaID int,
magn int,
afslattur float,
CONSTRAINT kaupPK PRIMARY KEY(afgID)
);

DROP TABLE IF EXISTS taken;
CREATE TABLE taken(
	ID varchar(10)
);

ALTER TABLE verslun ADD FOREIGN KEY (A_madur) REFERENCES staff(kt);
ALTER TABLE verslun ADD FOREIGN KEY (B_madur) REFERENCES staff(kt);
ALTER TABLE verslun ADD FOREIGN KEY (C_madur) REFERENCES staff(kt);
ALTER TABLE kaup ADD FOREIGN KEY (varaID) REFERENCES vorur(ID);
ALTER TABLE afgreidsla ADD FOREIGN KEY (ID) REFERENCES kaup(afgID);
ALTER TABLE afgreidsla ADD FOREIGN KEY (verslun_ID) REFERENCES verslun(ID);
ALTER TABLE afgreidsla ADD FOREIGN KEY (staff_kt) REFERENCES staff(kt);
ALTER TABLE staff ADD FOREIGN KEY (verslun_ID) REFERENCES verslun(ID);


INSERT INTO verslun(longi, lati, heimilisfang, opnunardags,m2) VALUES (64.1458419,-21.7568441,"Korputorg", "2010-02-27", 2500);

INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun_id,pass) VALUES (2410982069, "Pall Gudbrandsson", "Bitch", 2,0,"2015-07-31",1,md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun_id,pass) VALUES (2308982439, "Mani Karl Gudmundsson", "A-madur", 5,0,CURDATE(),1,md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun_id,pass) VALUES (0604982539, "Inga Kristin", "Kassadama", 0, 1,"2010-02-27", 1,md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun_id,pass) VALUES (2710560000, "Sigurdur R Ragnarsson", "King", 6,0,"2016-04-28", 1, md5("pass.1234"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun_id,pass) VALUES (0101900001, "Random1", "B-madur", 4,1, CURDATE(), 1, md5("pass.123"));
INSERT INTO staff(kt,nafn,titill,launaf,kyn,startD,verslun_id,pass) VALUES (0101900002, "Random2", "C-madur", 3,1, CURDATE(), 1, md5("pass.123"));

UPDATE verslun SET 
A_madur =2308982439,
B_madur =0101900001,
C_madur =0101900002
WHERE id = 1;