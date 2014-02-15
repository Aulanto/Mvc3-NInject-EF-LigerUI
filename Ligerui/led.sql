-- MySQL dump 10.13  Distrib 5.6.12, for Win64 (x86_64)
--
-- Host: localhost    Database: led
-- ------------------------------------------------------
-- Server version	5.6.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `role_rights`
--

DROP TABLE IF EXISTS `role_rights`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role_rights` (
  `roleid` int(11) NOT NULL AUTO_INCREMENT,
  `rid` int(11) NOT NULL,
  PRIMARY KEY (`roleid`,`rid`),
  KEY `rid_idx` (`rid`),
  KEY `roleid_idx` (`roleid`),
  CONSTRAINT `FK_role_rights_t_resources` FOREIGN KEY (`rid`) REFERENCES `t_resources` (`rid`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_role_rights_t_role` FOREIGN KEY (`roleid`) REFERENCES `t_role` (`roleid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='角色权限表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role_rights`
--

LOCK TABLES `role_rights` WRITE;
/*!40000 ALTER TABLE `role_rights` DISABLE KEYS */;
INSERT INTO `role_rights` VALUES (1,1),(2,1),(2,2),(2,3),(2,4),(1,5),(2,5),(1,6),(2,6),(2,7),(3,7),(1,8),(2,8),(3,8),(1,9),(2,9),(3,9);
/*!40000 ALTER TABLE `role_rights` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_user`
--

DROP TABLE IF EXISTS `role_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role_user` (
  `roleid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(50) NOT NULL,
  PRIMARY KEY (`roleid`,`userid`),
  KEY `userid_idx` (`userid`),
  KEY `roleid_idx` (`roleid`),
  CONSTRAINT `FK_role_user_t_role` FOREIGN KEY (`roleid`) REFERENCES `t_role` (`roleid`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_role_user_t_user` FOREIGN KEY (`userid`) REFERENCES `t_user` (`userid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role_user`
--

LOCK TABLES `role_user` WRITE;
/*!40000 ALTER TABLE `role_user` DISABLE KEYS */;
INSERT INTO `role_user` VALUES (1,'18000'),(2,'admin');
/*!40000 ALTER TABLE `role_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_org`
--

DROP TABLE IF EXISTS `t_org`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_org` (
  `orgcode` varchar(20) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `parentCode` varchar(20) DEFAULT NULL,
  `orgtype` int(11) DEFAULT NULL COMMENT '1：省 ，2： 市，3： 县/区，4：社区',
  PRIMARY KEY (`orgcode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='组织机构';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_org`
--

LOCK TABLES `t_org` WRITE;
/*!40000 ALTER TABLE `t_org` DISABLE KEYS */;
INSERT INTO `t_org` VALUES ('01','湖南省','',NULL),('02','衡阳市','01',NULL),('03','衡阳县','02',NULL),('04','衡南县','02',NULL),('05','衡山县','02',NULL),('06','衡东县','02',NULL),('07','祁东县','02',NULL),('08','集兵镇','03',NULL),('09','西渡镇','03',NULL),('10','长沙市','01',NULL);
/*!40000 ALTER TABLE `t_org` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_resources`
--

DROP TABLE IF EXISTS `t_resources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_resources` (
  `rid` int(11) NOT NULL AUTO_INCREMENT,
  `resources` varchar(60) DEFAULT NULL,
  `url` varchar(60) DEFAULT '#',
  `type` int(11) DEFAULT NULL COMMENT '1：ACTION ，2 ：功能',
  `parentrid` int(11) DEFAULT NULL,
  `tindex` int(11) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL COMMENT '页面名称',
  PRIMARY KEY (`rid`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT='权限资源表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_resources`
--

LOCK TABLES `t_resources` WRITE;
/*!40000 ALTER TABLE `t_resources` DISABLE KEYS */;
INSERT INTO `t_resources` VALUES (1,NULL,'11',NULL,NULL,1,'设备管理'),(2,NULL,'11',NULL,NULL,2,'节目单管理'),(3,NULL,'11',NULL,NULL,3,'日志查询'),(4,NULL,'11',NULL,NULL,4,'数据备份'),(5,NULL,'#',NULL,NULL,5,'系统管理'),(6,NULL,'~/Organization/Index',NULL,5,1,'组织结构管理'),(7,NULL,'~/Menu/Index',NULL,5,2,'菜单管理'),(8,NULL,'~/User/Index',NULL,5,3,'用户管理'),(9,NULL,'~/Role/Index',NULL,5,4,'角色管理');
/*!40000 ALTER TABLE `t_resources` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_role`
--

DROP TABLE IF EXISTS `t_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_role` (
  `roleid` int(11) NOT NULL,
  `rolename` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`roleid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_role`
--

LOCK TABLES `t_role` WRITE;
/*!40000 ALTER TABLE `t_role` DISABLE KEYS */;
INSERT INTO `t_role` VALUES (1,'采集员'),(2,'调度员'),(3,'质检员');
/*!40000 ALTER TABLE `t_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_user`
--

DROP TABLE IF EXISTS `t_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_user` (
  `userid` varchar(50) NOT NULL,
  `loginuser` varchar(50) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `orgcode` varchar(20) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`userid`),
  KEY `orgcode_idx` (`orgcode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_user`
--

LOCK TABLES `t_user` WRITE;
/*!40000 ALTER TABLE `t_user` DISABLE KEYS */;
INSERT INTO `t_user` VALUES ('18000',NULL,'测试员','01','admin'),('admin',NULL,'管理员','01','admin');
/*!40000 ALTER TABLE `t_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-08-04 19:52:59
