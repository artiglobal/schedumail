CREATE TABLE aspnet_Users ( 
	UserId varchar DEFAULT NULL NOT NULL,
	Username varchar DEFAULT NULL NOT NULL,
	LoweredUsername varchar DEFAULT NULL NOT NULL,
	ApplicationId varchar DEFAULT NULL NOT NULL,
	Email varchar DEFAULT NULL,
	LoweredEmail varchar DEFAULT NULL,
	Comment varchar DEFAULT NULL,
	Password varchar DEFAULT NULL NOT NULL,
	PasswordFormat varchar DEFAULT NULL NOT NULL,
	PasswordSalt varchar DEFAULT NULL NOT NULL,
	PasswordQuestion varchar DEFAULT NULL,
	PasswordAnswer varchar DEFAULT NULL,
	IsApproved bit DEFAULT NULL NOT NULL,
	IsAnonymous bit DEFAULT NULL NOT NULL,
	LastActivityDate date DEFAULT NULL NOT NULL,
	LastLoginDate date DEFAULT NULL NOT NULL,
	LastPasswordChangedDate date DEFAULT NULL NOT NULL,
	CreateDate date DEFAULT NULL NOT NULL,
	IsLockedOut bit DEFAULT NULL NOT NULL,
	LastLockoutDate date DEFAULT NULL NOT NULL,
	FailedPasswordAttemptCount long DEFAULT NULL NOT NULL,
	FailedPasswordAttemptWindowStart date DEFAULT NULL NOT NULL,
	FailedPasswordAnswerAttemptCount long DEFAULT NULL NOT NULL,
	FailedPasswordAnswerAttemptWindowStart date DEFAULT NULL NOT NULL
) 

;

























