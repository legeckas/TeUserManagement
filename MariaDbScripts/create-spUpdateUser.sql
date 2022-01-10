CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateUser`(
	IN `idp` INT,
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
	UPDATE `dbo.teusers`
	SET `firstname` = `firstnamep`,
		`lastname` = `lastnamep`,
		`age` = `agep`,
		`city` = `cityp`
	WHERE `id` = `idp`;
END