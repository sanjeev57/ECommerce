-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: ecommmerceorderprocessing
-- ------------------------------------------------------
-- Server version	8.0.22

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
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `items` (
  `item_id` varchar(40) NOT NULL,
  `item_name` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES ('I1','Lamp'),('I2','Chair');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetails` (
  `orderdetail_id` varchar(40) NOT NULL,
  `item_id` varchar(40) NOT NULL,
  `order_id` varchar(40) NOT NULL,
  `quantity` int DEFAULT NULL,
  PRIMARY KEY (`orderdetail_id`),
  KEY `item_id` (`item_id`),
  KEY `order_id` (`order_id`),
  CONSTRAINT `orderdetails_ibfk_1` FOREIGN KEY (`item_id`) REFERENCES `items` (`item_id`),
  CONSTRAINT `orderdetails_ibfk_2` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetails`
--

LOCK TABLES `orderdetails` WRITE;
/*!40000 ALTER TABLE `orderdetails` DISABLE KEYS */;
INSERT INTO `orderdetails` VALUES ('OD1','I1','O1',1),('OD2','I2','O2',2),('OD3','I1','O3',5),('OD4','I2','O4',5),('OD5','I1','O5',5),('OD6','I2','O6',5),('OD7','I2','O7',5),('OD8','I2','O8',2),('OD9','I1','O9',5);
/*!40000 ALTER TABLE `orderdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_id` varchar(40) NOT NULL,
  `customer_id` varchar(40) NOT NULL,
  `subtotal` float DEFAULT NULL,
  `tax` float NOT NULL,
  `shipamount` float DEFAULT NULL,
  `total` float NOT NULL,
  `status` varchar(45) DEFAULT NULL,
  `activeflag` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES ('O1','C1',20,1.5,3.5,25,'In Transition','0'),('O2','C2',100,18,10,128,'Received','0'),('O3','C2',200,1.5,3.5,250,'Order Cancelled','1'),('O4','C2',10,1.5,3.5,20,'Order Cancelled','1'),('O5','C2',200,1.5,3.5,250,'Delievered','0'),('O6','C2',10,1.5,3.5,20,'Delievered','0'),('O7','C2',10,1.5,3.5,20,'Delievered','0'),('O8','C3',1000,1.5,3.5,20000,'In Transition','0'),('O9','C2',200,1.5,3.5,250,'Received','0');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payment` (
  `payment_id` varchar(40) NOT NULL,
  `order_id` varchar(40) NOT NULL,
  `payment_month` varchar(40) DEFAULT NULL,
  `payment_date` varchar(40) DEFAULT NULL,
  `payment_confirmation` varchar(40) DEFAULT NULL,
  `billingadress` varchar(40) DEFAULT NULL,
  `city` varchar(40) DEFAULT NULL,
  `state` varchar(40) DEFAULT NULL,
  `zip` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`payment_id`),
  KEY `order_id` (`order_id`),
  CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES ('P1','O1','January','15','PC12021','190 Preston Road','Austin','Texas','78965'),('P2','O2','December','14','PC22021','121 Oaks Pl','Warwik','Rhode Island','02456'),('P3','O3','May','31','PC32021','190 Mira Road','Paris','Texas','78965'),('P4','O4','May','31','PC42021','190 Mira Road','Paris','Texas','78965'),('P5','O5','May','31','PC42021','190 Mira Road','Paris','Texas','78965'),('P6','O6','May','31','PC62021','190 Mira Road','Paris','Texas','78965'),('P7','O7','May','31','PC72021','190 Mira Road','Paris','Texas','78965'),('P8','O8','May','31','PC82021','190 Mira Road','Paris','Texas','78965'),('P9','O9','May','31','PC92021','190 Mira Road','Paris','Texas','78965');
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipping`
--

DROP TABLE IF EXISTS `shipping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shipping` (
  `shipping_id` varchar(40) NOT NULL,
  `order_id` varchar(40) NOT NULL,
  `shippingadress` varchar(40) DEFAULT NULL,
  `shippingcity` varchar(40) DEFAULT NULL,
  `shippingstate` varchar(40) DEFAULT NULL,
  `shippingzip` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`shipping_id`),
  KEY `order_id` (`order_id`),
  CONSTRAINT `shipping_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipping`
--

LOCK TABLES `shipping` WRITE;
/*!40000 ALTER TABLE `shipping` DISABLE KEYS */;
INSERT INTO `shipping` VALUES ('S1','O1','Summit Oaks','Raleigh','NC','576907'),('S2','O2','Green Tree','Seattle','WA','908675'),('S3','O3','Summit Ave','Providence','RI','576907'),('S4','O4','Summit Ave','Providence','RI','576907'),('S5','O5','Summit Ave','Providence','RI','576907'),('S6','O6','Summit Ave','Providence','RI','576907'),('S7','O7','Summit Ave','Providence','RI','576907'),('S8','O8','Summit Ave','Providence','RI','576907'),('S9','O9','Summit Ave','Providence','RI','576907');
/*!40000 ALTER TABLE `shipping` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-17 18:14:29
