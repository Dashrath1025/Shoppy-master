-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: shoppingdb
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `adminlogin`
--

DROP TABLE IF EXISTS `adminlogin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adminlogin` (
  `Aid` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `UpdationDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Aid`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adminlogin`
--

LOCK TABLES `adminlogin` WRITE;
/*!40000 ALTER TABLE `adminlogin` DISABLE KEYS */;
INSERT INTO `adminlogin` VALUES (7,'milanlimbani555@gmail.com','G0J86P45WE/oN6WaUk1fKXSlwip/sFRgFms5eg2jtCM=','2022-12-19 12:50:11','2022-12-26 13:34:24');
/*!40000 ALTER TABLE `adminlogin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `Categoyid` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(25) NOT NULL,
  `CategoryDescription` varchar(500) NOT NULL,
  `CreationDate` datetime NOT NULL,
  PRIMARY KEY (`Categoyid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Fashion','Fashion','2023-03-29 23:48:07'),(2,'Electornics','Electronics','2023-03-29 23:49:45');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `city` (
  `CityId` int NOT NULL AUTO_INCREMENT,
  `StateId` int NOT NULL,
  `Cityname` varchar(45) NOT NULL,
  PRIMARY KEY (`CityId`),
  KEY `StateId_idx` (`StateId`),
  CONSTRAINT `StateId` FOREIGN KEY (`StateId`) REFERENCES `state` (`StateId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,1,'Surat'),(2,2,'Jalgav');
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactus`
--

DROP TABLE IF EXISTS `contactus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contactus` (
  `ContactID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `UID` int NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Description` varchar(2000) NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ContactID`),
  KEY `UID_idx` (`UID`),
  CONSTRAINT `UID` FOREIGN KEY (`UID`) REFERENCES `userlogin` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactus`
--

LOCK TABLES `contactus` WRITE;
/*!40000 ALTER TABLE `contactus` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `country` (
  `CountryId` int NOT NULL AUTO_INCREMENT,
  `CountryName` varchar(45) NOT NULL,
  `CreationDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CountryId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'India','2023-03-29 23:53:02');
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetails` (
  `OID` int NOT NULL AUTO_INCREMENT,
  `UID` int NOT NULL,
  `ProductID` int NOT NULL,
  `PaymentID` varchar(50) NOT NULL,
  `DateTime` datetime DEFAULT NULL,
  `OrderStatus` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`OID`),
  KEY `UserID_idx` (`UID`),
  KEY `ProductId_idx` (`ProductID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetails`
--

LOCK TABLES `orderdetails` WRITE;
/*!40000 ALTER TABLE `orderdetails` DISABLE KEYS */;
INSERT INTO `orderdetails` VALUES (1,25,6,'pay_LXfs5GA4KGAmoU','2023-03-30 14:15:11','Delivered');
/*!40000 ALTER TABLE `orderdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `ProductId` int NOT NULL AUTO_INCREMENT,
  `CatID` int NOT NULL,
  `SubCatID` int NOT NULL,
  `productName` varchar(45) NOT NULL,
  `ProductCompany` varchar(45) NOT NULL,
  `ProductPrice` int NOT NULL,
  `ProductPriceBeforeDiscount` int NOT NULL,
  `Discount` int NOT NULL,
  `ProductDescription` varchar(1000) NOT NULL,
  `ShippingCharge` int NOT NULL,
  `ProductImage1` varchar(1000) NOT NULL,
  `ProductImage2` varchar(1000) NOT NULL,
  `ProductImage3` varchar(1000) NOT NULL,
  `ProductAvailability` int NOT NULL,
  `PostingDate` datetime NOT NULL,
  PRIMARY KEY (`ProductId`),
  KEY `CatID_idx` (`CatID`),
  KEY `SubCatID_idx` (`SubCatID`),
  CONSTRAINT `CatID` FOREIGN KEY (`CatID`) REFERENCES `category` (`Categoyid`),
  CONSTRAINT `SubCatID` FOREIGN KEY (`SubCatID`) REFERENCES `subcategory` (`SubCategoryId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (5,1,1,'Shoes','Adidas',1000,800,200,'Men Shoes - Myntra offers a wide range of Shoes for men online. Shop for best casual, formal, sports Shoes for Men at 50% - 90% off on top brands on Myntra.',0,'~/UploadedImages/product-8-thumb.jpg','~/UploadedImages/product-8-thumb.jpg','~/UploadedImages/product-8-thumb.jpg',3,'2023-03-30 00:38:15'),(6,2,2,'Washing Machine','IFB',20,10,10,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(7,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(8,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(9,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(10,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(11,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(12,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(13,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31'),(14,2,2,'Washing Machine','IFB',15000,13000,2000,'IFB Washing Machines use innovation & tech to bring convenience to your washing needs. From Front Loaders to Top Loaders to Smart Loaders washing machine',0,'~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg','~/UploadedImages/10012.jpg',4,'2023-03-30 00:41:31');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchaseproduct`
--

DROP TABLE IF EXISTS `purchaseproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchaseproduct` (
  `PurchaseProductID` int NOT NULL AUTO_INCREMENT,
  `ProductId` int NOT NULL,
  `Productname` varchar(45) NOT NULL,
  `ProductPrice` int NOT NULL,
  `UsersID` int NOT NULL,
  `DateTime` datetime NOT NULL,
  `DeliveredDate` varchar(45) DEFAULT NULL,
  `ProductStatus` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`PurchaseProductID`),
  KEY `UserID_idx` (`UsersID`),
  CONSTRAINT `UsersID` FOREIGN KEY (`UsersID`) REFERENCES `userlogin` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchaseproduct`
--

LOCK TABLES `purchaseproduct` WRITE;
/*!40000 ALTER TABLE `purchaseproduct` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchaseproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ratingview`
--

DROP TABLE IF EXISTS `ratingview`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ratingview` (
  `Rid` int NOT NULL AUTO_INCREMENT,
  `PID` int NOT NULL,
  `Uname` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Rating` varchar(20) COLLATE utf8mb4_croatian_ci NOT NULL,
  `RatingDate` datetime NOT NULL,
  PRIMARY KEY (`Rid`),
  KEY `PID_idx` (`PID`),
  CONSTRAINT `PID` FOREIGN KEY (`PID`) REFERENCES `products` (`ProductId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_croatian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ratingview`
--

LOCK TABLES `ratingview` WRITE;
/*!40000 ALTER TABLE `ratingview` DISABLE KEYS */;
/*!40000 ALTER TABLE `ratingview` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `state`
--

DROP TABLE IF EXISTS `state`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `state` (
  `StateId` int NOT NULL AUTO_INCREMENT,
  `CountryId` int NOT NULL,
  `StateName` varchar(45) NOT NULL,
  PRIMARY KEY (`StateId`),
  KEY `CountryId_idx` (`CountryId`),
  CONSTRAINT `CountryId` FOREIGN KEY (`CountryId`) REFERENCES `country` (`CountryId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `state`
--

LOCK TABLES `state` WRITE;
/*!40000 ALTER TABLE `state` DISABLE KEYS */;
INSERT INTO `state` VALUES (1,1,'Gujarat'),(2,1,'Punjab');
/*!40000 ALTER TABLE `state` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subcategory`
--

DROP TABLE IF EXISTS `subcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subcategory` (
  `SubCategoryId` int NOT NULL AUTO_INCREMENT,
  `CategoryId` int DEFAULT NULL,
  `SubCategoryName` varchar(45) NOT NULL,
  `CreationDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SubCategoryId`),
  KEY `CategoryId_idx` (`CategoryId`),
  CONSTRAINT `CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Categoyid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subcategory`
--

LOCK TABLES `subcategory` WRITE;
/*!40000 ALTER TABLE `subcategory` DISABLE KEYS */;
INSERT INTO `subcategory` VALUES (1,1,'Shoes','2023-03-29 23:48:24'),(2,1,'Woman\'s clothes','2023-03-29 23:49:14'),(3,2,'WashingMachine','2023-03-29 23:50:02'),(4,2,'TV','2023-03-29 23:50:11');
/*!40000 ALTER TABLE `subcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcart`
--

DROP TABLE IF EXISTS `tblcart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblcart` (
  `CartID` int NOT NULL AUTO_INCREMENT,
  `UseID` int NOT NULL,
  `ProductId` int NOT NULL,
  `productName` varchar(45) NOT NULL,
  `ProductPrice` int NOT NULL,
  `ProductPriceBeforeDiscount` int NOT NULL,
  `Qty` int DEFAULT NULL,
  PRIMARY KEY (`CartID`),
  KEY `UserID_idx` (`UseID`),
  CONSTRAINT `UseID` FOREIGN KEY (`UseID`) REFERENCES `userlogin` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcart`
--

LOCK TABLES `tblcart` WRITE;
/*!40000 ALTER TABLE `tblcart` DISABLE KEYS */;
INSERT INTO `tblcart` VALUES (2,25,6,'Washing Machine',20,10,1);
/*!40000 ALTER TABLE `tblcart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraddress`
--

DROP TABLE IF EXISTS `useraddress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraddress` (
  `AddressID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `BillingFirstname` varchar(45) NOT NULL,
  `BillingMiddlename` varchar(45) NOT NULL,
  `BillingLastname` varchar(45) NOT NULL,
  `BillingEmail` varchar(45) NOT NULL,
  `BillingMobileno` varchar(45) NOT NULL,
  `BillingAddress` varchar(500) NOT NULL,
  `BillingCountry` int NOT NULL,
  `BillingState` int NOT NULL,
  `BillingCity` int NOT NULL,
  `BillingPincode` varchar(6) NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`AddressID`),
  KEY `UserEmail_idx` (`UserID`),
  KEY `BillingCountry_idx` (`BillingCountry`),
  KEY `BillingState_idx` (`BillingState`),
  KEY `BillingCity_idx` (`BillingCity`),
  CONSTRAINT `BillingCity` FOREIGN KEY (`BillingCity`) REFERENCES `city` (`CityId`),
  CONSTRAINT `BillingCountry` FOREIGN KEY (`BillingCountry`) REFERENCES `country` (`CountryId`),
  CONSTRAINT `BillingState` FOREIGN KEY (`BillingState`) REFERENCES `state` (`StateId`),
  CONSTRAINT `UserID` FOREIGN KEY (`UserID`) REFERENCES `userlogin` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraddress`
--

LOCK TABLES `useraddress` WRITE;
/*!40000 ALTER TABLE `useraddress` DISABLE KEYS */;
INSERT INTO `useraddress` VALUES (1,25,'milan','r','limbani','milanlimbani555@gmail.com','6359784404','46\r\nPRABHUDARSHAN ROW HOUSE\r\nSHYAMDHAM CHOWK ,PUNAGAM ,',1,1,1,'395010','2023-03-30 01:06:00'),(2,25,'milan','r','limbani','milanlimbani555@gmail.com','6359784404','46\r\nPRABHUDARSHAN ROW HOUSE\r\nSHYAMDHAM CHOWK ,PUNAGAM ,',1,1,1,'395010','2023-03-30 14:14:28');
/*!40000 ALTER TABLE `useraddress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userlogin`
--

DROP TABLE IF EXISTS `userlogin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userlogin` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(45) NOT NULL,
  `UserOtp` int NOT NULL,
  `Datetime` datetime NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userlogin`
--

LOCK TABLES `userlogin` WRITE;
/*!40000 ALTER TABLE `userlogin` DISABLE KEYS */;
INSERT INTO `userlogin` VALUES (25,'milanlimbani555@gmail.com',3042,'2023-03-30 14:12:39');
/*!40000 ALTER TABLE `userlogin` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-30 15:40:12
