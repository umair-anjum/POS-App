-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.18-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema posisdb_csharp
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ posisdb_csharp;
USE posisdb_csharp;

--
-- Table structure for table `posisdb_csharp`.`attransactiondetails`
--

DROP TABLE IF EXISTS `attransactiondetails`;
CREATE TABLE `attransactiondetails` (
  `ATTDID` int(10) unsigned NOT NULL auto_increment,
  `ATPrice` double NOT NULL default '0',
  `Quantity` int(10) unsigned NOT NULL default '0',
  `ProductName` varchar(64) NOT NULL default '',
  `ATInvoiceNo` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`ATTDID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`attransactiondetails`
--

/*!40000 ALTER TABLE `attransactiondetails` DISABLE KEYS */;
INSERT INTO `attransactiondetails` (`ATTDID`,`ATPrice`,`Quantity`,`ProductName`,`ATInvoiceNo`) VALUES 
 (3,5,1,'VODACOM R5','100100062'),
 (4,50,1,'TELKOM R50','100100062'),
 (5,5,1,'CELL C R5','100100066'),
 (6,10,1,'CELL C R10','100100066'),
 (7,25,1,'CELL C R25','100100066');
/*!40000 ALTER TABLE `attransactiondetails` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`atvoucher`
--

DROP TABLE IF EXISTS `atvoucher`;
CREATE TABLE `atvoucher` (
  `ATVoucherID` int(10) unsigned NOT NULL auto_increment,
  `Supplier` varchar(45) NOT NULL default '',
  `Product` varchar(45) NOT NULL default '',
  `VoucherNo` varchar(45) NOT NULL default '',
  `ExpiryDate` varchar(45) NOT NULL default '',
  `PINNo` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`ATVoucherID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`atvoucher`
--

/*!40000 ALTER TABLE `atvoucher` DISABLE KEYS */;
INSERT INTO `atvoucher` (`ATVoucherID`,`Supplier`,`Product`,`VoucherNo`,`ExpiryDate`,`PINNo`) VALUES 
 (1,'VODACOM','R5','100100062','12/31/2016','263209252712'),
 (2,'TELKOM','R50','100100062','12/31/2016','263209252712'),
 (3,'CELL C','R5','100100066','12/31/2016','263209252712'),
 (4,'CELL C','R10','100100066','12/31/2016','263209252712'),
 (5,'CELL C','R25','100100066','12/31/2016','263209252712');
/*!40000 ALTER TABLE `atvoucher` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`category`
--

DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `CategoryNo` int(10) unsigned NOT NULL auto_increment,
  `CategoryName` varchar(45) NOT NULL default '',
  `Description` varchar(150) NOT NULL default '',
  PRIMARY KEY  (`CategoryNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`category`
--

/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` (`CategoryNo`,`CategoryName`,`Description`) VALUES 
 (1,'Bags','All bags will belong to this category'),
 (2,'SHOES','SHOES'),
 (3,'Gadget ','Gadget category'),
 (4,'Medicine','Medicine Category');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`company`
--

DROP TABLE IF EXISTS `company`;
CREATE TABLE `company` (
  `CompanyID` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(250) NOT NULL default '',
  `Address` varchar(250) default '',
  `PhoneNo` varchar(45) default '',
  `Email` varchar(100) default '',
  `Website` varchar(100) default '',
  `TINNumber` varchar(100) default '',
  PRIMARY KEY  (`CompanyID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`company`
--

/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` (`CompanyID`,`Name`,`Address`,`PhoneNo`,`Email`,`Website`,`TINNumber`) VALUES 
 (1,'CyberVineyard SS','Kidapawan City, Philippines','12312312','cybernick75@gmail.com','www.cvss.com','2131-232-3232');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`payment`
--

DROP TABLE IF EXISTS `payment`;
CREATE TABLE `payment` (
  `paymentNo` int(10) unsigned NOT NULL auto_increment,
  `InvoiceNo` int(10) unsigned NOT NULL default '0',
  `Cash` double NOT NULL default '0',
  `PChange` double NOT NULL default '0',
  PRIMARY KEY  (`paymentNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`payment`
--

/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` (`paymentNo`,`InvoiceNo`,`Cash`,`PChange`) VALUES 
 (1,100100001,2000,500),
 (2,100100002,3000,151),
 (3,100100003,2000,0),
 (4,100100004,20000,0),
 (5,100100005,2000,500),
 (6,100100006,10000,0),
 (7,100100007,2000,0),
 (8,100100008,2000,0),
 (9,100100009,1500,0),
 (10,100100010,5000,150),
 (11,100100012,4000,500),
 (12,100100014,2000,0),
 (13,100100016,22000,500),
 (14,100100018,3500,0),
 (15,100100019,1500,0),
 (16,100100021,4000,500),
 (17,100100022,2000,500),
 (18,100100024,4000,500),
 (19,100100023,3500,0),
 (20,100100026,3500,0),
 (21,100100027,1500,0),
 (22,100100025,4500,0),
 (23,100100028,1500,0),
 (24,100100028,1500,0),
 (25,100100029,1500,0),
 (26,100100030,24000,0),
 (27,100100031,2000,0),
 (28,100100032,3500,0),
 (29,100100033,25500,0),
 (30,100100034,27000,500),
 (31,100100035,27000,0),
 (32,100100036,32000,500),
 (33,100100037,26000,500),
 (34,100100038,26000,500),
 (35,100100039,50000,4500),
 (36,100100040,28000,500),
 (37,100100041,1500,0),
 (38,100100042,1500,0),
 (39,100100043,1500,0);
INSERT INTO `payment` (`paymentNo`,`InvoiceNo`,`Cash`,`PChange`) VALUES 
 (40,100100044,29000,500),
 (41,100100045,2000,500),
 (42,100100046,3000,500),
 (43,100100047,1000,0),
 (44,100100048,9000,150),
 (45,100100049,5000,800),
 (46,100100050,2000,0),
 (47,100100051,24000,500),
 (48,100100052,4500,0),
 (49,100100053,3500,0),
 (50,100100054,3500,0),
 (51,100100055,2200,0),
 (52,100100056,1500,0),
 (53,100100057,1500,0),
 (54,100100058,1500,0),
 (55,100100057,1500,0),
 (56,100100058,1500,0),
 (57,100100059,2000,0),
 (58,100100060,1500,0),
 (59,100100061,2500,0),
 (60,100100062,3500,0),
 (61,100100063,25000,0),
 (62,100100064,3500,0),
 (63,100100065,3500,0),
 (64,100100066,1500,0);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`product`
--

DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `ProductNo` int(10) unsigned NOT NULL auto_increment,
  `ProductCode` varchar(45) NOT NULL default '',
  `Description` varchar(200) NOT NULL default '',
  `Barcode` varchar(50) NOT NULL default '',
  `UnitPrice` double NOT NULL default '0',
  `StocksOnHand` double NOT NULL default '0',
  `ReorderLevel` int(10) unsigned NOT NULL default '0',
  `CategoryNo` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ProductNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`product`
--

/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` (`ProductNo`,`ProductCode`,`Description`,`Barcode`,`UnitPrice`,`StocksOnHand`,`ReorderLevel`,`CategoryNo`) VALUES 
 (1,'PBAG','Pack Bag Jansport Large','111',1500,171.4,5,1),
 (2,'PARACETAMOL','PARACETAMOL','222',2000,4,2,4),
 (3,'LTOP','Toshiba Laptop','333',20000,0,1,3),
 (4,'NNIKE','NIKE SHOWS NEW MODEL','112',1000,1079,5,2),
 (5,'ADIDAS','Adidas Black','444',2000,89,5,2);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`staff`
--

DROP TABLE IF EXISTS `staff`;
CREATE TABLE `staff` (
  `StaffID` int(10) unsigned NOT NULL auto_increment,
  `Lastname` varchar(45) NOT NULL default '',
  `Firstname` varchar(45) NOT NULL default '',
  `MI` varchar(1) NOT NULL default '',
  `Street` varchar(45) NOT NULL default '',
  `Barangay` varchar(45) NOT NULL default '',
  `City` varchar(45) NOT NULL default '',
  `Province` varchar(45) NOT NULL default '',
  `ContactNo` varchar(45) NOT NULL default '',
  `Username` varchar(45) NOT NULL default '',
  `Role` varchar(45) NOT NULL default '',
  `UPassword` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`StaffID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`staff`
--

/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` (`StaffID`,`Lastname`,`Firstname`,`MI`,`Street`,`Barangay`,`City`,`Province`,`ContactNo`,`Username`,`Role`,`UPassword`) VALUES 
 (1,'System','Admin','','Purok B','Balindog','Kidapawan','North Cotabato','09466903269','admin','Admin','admin'),
 (2,'Rojas','Nick','E','Purok 1','lanao','Kidapawan City','Testing','0846890823','nick','Admin','1234'),
 (3,'Kishe','Hon','T','Purok 5','Lanao','Kidapawan','North Cot','918231293','kishe','Cashier','kish');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`stockin`
--

DROP TABLE IF EXISTS `stockin`;
CREATE TABLE `stockin` (
  `StockInNo` int(10) unsigned NOT NULL auto_increment,
  `ProductNo` int(10) unsigned NOT NULL default '0',
  `Quantity` double NOT NULL default '0',
  `DateIn` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`StockInNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`stockin`
--

/*!40000 ALTER TABLE `stockin` DISABLE KEYS */;
INSERT INTO `stockin` (`StockInNo`,`ProductNo`,`Quantity`,`DateIn`) VALUES 
 (1,1,20,'12/31/2013'),
 (2,2,20,'09/30/2015'),
 (3,2,10,'09/30/2015'),
 (4,3,10,'09/30/2015'),
 (5,2,10,'09/30/2015'),
 (6,3,5,'09/30/2015'),
 (7,4,1000,'07/18/2016'),
 (8,5,100,'07/19/2016'),
 (9,1,100,'07/19/2016'),
 (10,4,100,'07/19/2016'),
 (11,1,10,'07/21/2016'),
 (12,1,100,'07/21/2016');
/*!40000 ALTER TABLE `stockin` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`transactiondetails`
--

DROP TABLE IF EXISTS `transactiondetails`;
CREATE TABLE `transactiondetails` (
  `TDetailNo` int(10) unsigned NOT NULL auto_increment,
  `InvoiceNo` varchar(50) NOT NULL default '',
  `ProductNo` int(10) unsigned NOT NULL default '0',
  `ItemPrice` double NOT NULL default '0',
  `Quantity` double NOT NULL default '0',
  `Discount` double NOT NULL default '0',
  PRIMARY KEY  (`TDetailNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`transactiondetails`
--

/*!40000 ALTER TABLE `transactiondetails` DISABLE KEYS */;
INSERT INTO `transactiondetails` (`TDetailNo`,`InvoiceNo`,`ProductNo`,`ItemPrice`,`Quantity`,`Discount`) VALUES 
 (2,'100100001',1,1500,1,0),
 (3,'100100002',1,1350,1,150),
 (4,'100100003',2,2000,1,0),
 (5,'100100004',3,20000,1,0),
 (6,'100100005',1,1500,1,0),
 (7,'100100006',2,2000,5,0),
 (8,'100100007',2,2000,1,0),
 (9,'100100008',2,2000,1,0),
 (10,'100100009',1,1500,1,0),
 (11,'100100010',1,1500,1,0),
 (12,'100100010',2,2000,1,0),
 (13,'100100010',1,1350,1,150),
 (14,'100100012',1,1500,1,0),
 (15,'100100012',2,2000,1,0),
 (16,'100100014',2,2000,1,0),
 (17,'100100016',1,1500,1,0),
 (18,'100100016',3,20000,1,0),
 (19,'100100018',1,1500,1,0),
 (20,'100100018',2,2000,1,0),
 (21,'100100019',1,1500,1,0),
 (22,'100100021',1,1500,1,0),
 (23,'100100021',2,2000,1,0),
 (24,'100100022',1,1500,1,0),
 (25,'100100024',1,1500,1,0),
 (26,'100100024',2,2000,1,0),
 (27,'100100023',1,1500,1,0),
 (28,'100100023',2,2000,1,0),
 (29,'100100026',1,1500,1,0),
 (30,'100100026',2,2000,1,0),
 (31,'100100027',1,1500,1,0),
 (32,'100100025',1,1500,1,0);
INSERT INTO `transactiondetails` (`TDetailNo`,`InvoiceNo`,`ProductNo`,`ItemPrice`,`Quantity`,`Discount`) VALUES 
 (33,'100100025',2,2000,1,0),
 (34,'100100025',4,1000,1,0),
 (35,'100100028',1,1500,1,0),
 (36,'100100028',1,1500,1,0),
 (37,'100100029',1,1500,1,0),
 (38,'100100030',2,2000,1,0),
 (39,'100100030',3,20000,1,0),
 (40,'100100030',5,2000,1,0),
 (41,'100100031',5,2000,1,0),
 (42,'100100032',1,1500,1,0),
 (43,'100100032',2,2000,1,0),
 (44,'100100033',1,1500,1,0),
 (45,'100100033',2,2000,1,0),
 (46,'100100033',3,20000,1,0),
 (47,'100100033',5,2000,1,0),
 (48,'100100034',1,1500,1,0),
 (49,'100100034',2,2000,1,0),
 (50,'100100034',3,20000,1,0),
 (51,'100100034',5,2000,1,0),
 (52,'100100034',4,1000,1,0),
 (53,'100100035',1,1500,1,0),
 (54,'100100035',2,2000,1,0),
 (55,'100100035',3,20000,1,0),
 (56,'100100035',5,2000,1,0),
 (57,'100100035',1,1500,1,0),
 (58,'100100036',1,1500,1,0),
 (59,'100100036',2,2000,1,0),
 (60,'100100036',3,20000,1,0),
 (61,'100100036',5,2000,1,0),
 (62,'100100036',1,1500,1,0),
 (63,'100100036',2,2000,1,0);
INSERT INTO `transactiondetails` (`TDetailNo`,`InvoiceNo`,`ProductNo`,`ItemPrice`,`Quantity`,`Discount`) VALUES 
 (64,'100100036',1,1500,1,0),
 (65,'100100036',4,1000,1,0),
 (66,'100100037',1,1500,1,0),
 (67,'100100037',2,2000,1,0),
 (68,'100100037',4,1000,1,0),
 (69,'100100037',4,1000,1,0),
 (70,'100100037',3,20000,1,0),
 (71,'100100038',1,1500,1,0),
 (72,'100100038',4,1000,1,0),
 (73,'100100038',4,1000,1,0),
 (74,'100100038',3,20000,1,0),
 (75,'100100038',5,2000,1,0),
 (76,'100100039',1,1500,1,0),
 (77,'100100039',4,1000,1,0),
 (78,'100100039',4,1000,1,0),
 (79,'100100039',3,20000,1,0),
 (80,'100100039',5,2000,1,0),
 (81,'100100039',3,20000,1,0),
 (82,'100100040',1,1500,1,0),
 (83,'100100040',2,2000,1,0),
 (84,'100100040',3,20000,1,0),
 (85,'100100040',5,2000,1,0),
 (86,'100100040',4,1000,1,0),
 (87,'100100040',4,1000,1,0),
 (88,'100100041',1,1500,1,0),
 (89,'100100042',1,1500,1,0),
 (90,'100100043',1,1500,1,0),
 (91,'100100044',1,1500,1,0),
 (92,'100100044',4,1000,1,0),
 (93,'100100044',4,1000,1,0),
 (94,'100100044',2,2000,1,0);
INSERT INTO `transactiondetails` (`TDetailNo`,`InvoiceNo`,`ProductNo`,`ItemPrice`,`Quantity`,`Discount`) VALUES 
 (95,'100100044',3,20000,1,0),
 (96,'100100044',5,2000,1,0),
 (97,'100100044',4,1000,1,0),
 (98,'100100045',1,1500,1,0),
 (99,'100100046',1,1500,1,0),
 (100,'100100046',4,1000,1,0),
 (101,'100100047',4,1000,1,0),
 (102,'100100048',1,1500,3.4,0),
 (103,'100100048',4,1000,1,0),
 (104,'100100048',4,1000,5.5,2750),
 (105,'100100049',1,1500,5.6,4200),
 (106,'100100050',4,1000,1,500),
 (107,'100100050',1,1500,1,0),
 (108,'100100051',1,1500,1,0),
 (109,'100100051',2,2000,1,0),
 (110,'100100051',3,20000,1,0),
 (111,'100100052',1,1500,1,0),
 (112,'100100052',2,2000,1,0),
 (113,'100100052',4,1000,1,0),
 (114,'100100053',1,1500,1,0),
 (115,'100100053',2,2000,1,0),
 (116,'100100054',1,1500,1,0),
 (117,'100100054',2,2000,1,0),
 (118,'100100055',4,1000,1,0),
 (119,'100100055',1,1500,1,300),
 (120,'100100056',1,1500,1,0),
 (123,'100100058',1,1500,1,0),
 (124,'100100059',2,2000,1,0),
 (125,'100100060',1,1500,1,0),
 (126,'100100061',1,1500,1,0);
INSERT INTO `transactiondetails` (`TDetailNo`,`InvoiceNo`,`ProductNo`,`ItemPrice`,`Quantity`,`Discount`) VALUES 
 (127,'100100061',4,1000,1,0),
 (128,'100100062',1,1500,1,0),
 (129,'100100062',2,2000,1,0),
 (130,'100100063',4,1000,1,0),
 (131,'100100063',2,2000,1,0),
 (132,'100100063',3,20000,1,0),
 (133,'100100063',5,2000,1,0),
 (134,'100100064',1,1500,1,0),
 (135,'100100064',2,2000,1,0),
 (136,'100100065',1,1500,1,0),
 (137,'100100065',2,2000,1,0),
 (138,'100100066',1,1500,1,0);
/*!40000 ALTER TABLE `transactiondetails` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`transactions`
--

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE `transactions` (
  `InvoiceNo` int(10) unsigned NOT NULL auto_increment,
  `TDate` varchar(45) NOT NULL default '',
  `TTime` varchar(45) NOT NULL default '',
  `NonVatTotal` double NOT NULL default '0',
  `VatAmount` double NOT NULL default '0',
  `TotalAmount` varchar(45) NOT NULL default '',
  `StaffID` int(11) NOT NULL default '0',
  PRIMARY KEY  (`InvoiceNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`transactions`
--

/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` (`InvoiceNo`,`TDate`,`TTime`,`NonVatTotal`,`VatAmount`,`TotalAmount`,`StaffID`) VALUES 
 (100100001,'09/30/2015','04:59:36',1500,0,'1,500.00',1),
 (100100002,'09/30/2015','05:01:24',2849,0,'2,849.00',1),
 (100100003,'09/30/2015','05:17:00',1760,240,'2,000.00',1),
 (100100004,'09/30/2015','05:21:54',17600,2400,'20,000.00',1),
 (100100005,'02/09/2016','05:43:26',1320,180,'1,500.00',1),
 (100100006,'03/01/2016','08:53:39',8800,1200,'10,000.00',1),
 (100100007,'03/05/2016','07:09:40',1760,240,'2,000.00',1),
 (100100008,'03/14/2016','07:56:49',1760,240,'2,000.00',1),
 (100100009,'05/25/2016','09:05:18',1320,180,'1,500.00',1),
 (100100010,'06/14/2016','08:24:32',4268,582,'4,850.00',1),
 (100100012,'07/18/2016','02:51:02',3080,420,'3,500.00',1),
 (100100014,'07/18/2016','02:52:53',1760,240,'2,000.00',1),
 (100100016,'07/18/2016','02:53:51',18920,2580,'21,500.00',1),
 (100100018,'07/18/2016','03:27:44',3080,420,'3,500.00',1),
 (100100019,'07/18/2016','03:27:58',1320,180,'1,500.00',1),
 (100100021,'07/18/2016','03:29:57',3080,420,'3,500.00',1);
INSERT INTO `transactions` (`InvoiceNo`,`TDate`,`TTime`,`NonVatTotal`,`VatAmount`,`TotalAmount`,`StaffID`) VALUES 
 (100100022,'07/18/2016','03:30:08',1320,180,'1,500.00',1),
 (100100023,'07/18/2016','03:38:49',3080,420,'3,500.00',1),
 (100100024,'07/18/2016','03:38:38',3080,420,'3,500.00',1),
 (100100025,'07/18/2016','03:54:01',3960,540,'4,500.00',1),
 (100100026,'07/18/2016','03:53:16',3080,420,'3,500.00',1),
 (100100027,'07/18/2016','03:53:31',1320,180,'1,500.00',1),
 (100100028,'07/18/2016','09:24:34',1320,180,'1,500.00',1),
 (100100029,'07/19/2016','10:27:18',1320,180,'1,500.00',1),
 (100100030,'07/19/2016','10:28:31',21120,2880,'24,000.00',1),
 (100100031,'07/19/2016','10:29:00',1760,240,'2,000.00',1),
 (100100032,'07/20/2016','07:41:45',3080,420,'3,500.00',1),
 (100100033,'07/20/2016','07:43:56',22440,3060,'25,500.00',1),
 (100100034,'07/20/2016','07:46:19',23320,3180,'26,500.00',1),
 (100100035,'07/20/2016','07:47:21',23760,3240,'27,000.00',1),
 (100100036,'07/20/2016','07:49:14',27720,3780,'31,500.00',1),
 (100100037,'07/20/2016','07:50:06',22440,3060,'25,500.00',1);
INSERT INTO `transactions` (`InvoiceNo`,`TDate`,`TTime`,`NonVatTotal`,`VatAmount`,`TotalAmount`,`StaffID`) VALUES 
 (100100038,'07/20/2016','07:52:07',22440,3060,'25,500.00',1),
 (100100039,'07/20/2016','07:53:09',40040,5460,'45,500.00',1),
 (100100040,'07/20/2016','07:55:16',24200,3300,'27,500.00',1),
 (100100041,'07/20/2016','07:55:33',1320,180,'1,500.00',1),
 (100100042,'07/20/2016','07:56:08',1320,180,'1,500.00',1),
 (100100043,'07/20/2016','07:56:37',1320,180,'1,500.00',1),
 (100100044,'07/20/2016','07:57:00',25080,3420,'28,500.00',1),
 (100100045,'07/20/2016','07:57:50',1320,180,'1,500.00',1),
 (100100046,'07/20/2016','07:58:38',2200,300,'2,500.00',1),
 (100100047,'07/20/2016','08:00:14',880,120,'1,000.00',1),
 (100100048,'07/20/2016','08:54:53',7788,1062,'8,850.00',1),
 (100100049,'07/20/2016','08:56:04',3696,504,'4,200.00',1),
 (100100050,'07/20/2016','08:57:37',1760,240,'2,000.00',1),
 (100100051,'07/21/2016','08:20:07',20680,2820,'23,500.00',3),
 (100100052,'07/21/2016','08:26:17',3960,540,'4,500.00',3),
 (100100053,'07/21/2016','08:46:39',3080,420,'3,500.00',3);
INSERT INTO `transactions` (`InvoiceNo`,`TDate`,`TTime`,`NonVatTotal`,`VatAmount`,`TotalAmount`,`StaffID`) VALUES 
 (100100054,'07/21/2016','08:47:36',3080,420,'3,500.00',3),
 (100100055,'07/21/2016','09:10:33',1760,440,'2,200.00',1),
 (100100056,'07/21/2016','09:14:22',1200,300,'1,500.00',3),
 (100100057,'07/22/2016','12:19:23',1200,300,'1,500.00',1),
 (100100058,'07/22/2016','12:20:43',1200,300,'1,500.00',1),
 (100100059,'07/22/2016','12:21:36',1600,400,'2,000.00',1),
 (100100060,'07/22/2016','12:23:46',1200,300,'1,500.00',1),
 (100100061,'07/22/2016','12:26:14',2000,500,'2,500.00',1),
 (100100062,'07/22/2016','12:28:25',2800,700,'3,500.00',1),
 (100100063,'07/22/2016','04:30:34',20000,5000,'25,000.00',1),
 (100100064,'07/22/2016','07:44:39',2800,700,'3,500.00',1),
 (100100065,'07/22/2016','07:46:35',2800,700,'3,500.00',1),
 (100100066,'07/22/2016','07:47:05',1200,300,'1,500.00',1);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;


--
-- Table structure for table `posisdb_csharp`.`vatsetting`
--

DROP TABLE IF EXISTS `vatsetting`;
CREATE TABLE `vatsetting` (
  `VatID` int(10) unsigned NOT NULL auto_increment,
  `VatPercent` double NOT NULL default '0',
  PRIMARY KEY  (`VatID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posisdb_csharp`.`vatsetting`
--

/*!40000 ALTER TABLE `vatsetting` DISABLE KEYS */;
INSERT INTO `vatsetting` (`VatID`,`VatPercent`) VALUES 
 (2,20);
/*!40000 ALTER TABLE `vatsetting` ENABLE KEYS */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
