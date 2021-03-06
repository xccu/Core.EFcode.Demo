CREATE TABLE `user_course` (
  `USER_ID` INT(6) NOT NULL,
  `COURSE_ID` INT(6) NOT NULL,
  `score` DOUBLE DEFAULT 0,
  PRIMARY KEY (`USER_ID`,`COURSE_ID`),
  CONSTRAINT fk_user FOREIGN KEY(USER_ID) REFERENCES USER(user_id),
  CONSTRAINT fk_course FOREIGN KEY(COURSE_ID) REFERENCES course(course_id)
) ENGINE=INNODB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8