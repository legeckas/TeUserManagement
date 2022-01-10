CREATE DEFINER=`root`@`localhost` PROCEDURE `spAddUser`(
	IN `firstnamep` CHAR(100),
	IN `lastnamep` CHAR(100),
	IN `agep` INT,
	IN `cityp` CHAR(50)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
	INSERT INTO `dbo.teusers`
	(
		`firstname`,
		`lastname`,
		`age`,
		`city`,
		`timecreated`
	)
	VALUES
	(
		`firstnamep`,
		`lastnamep`,
		`agep`,
		`cityp`,
		CURRENT_TIMESTAMP()
	);	
END