CREATE DATABASE [proapptest];

CREATE TABLE products
( 
	id decimal(3,0),
	name VARCHAR(255) NOT NULL,
    amount decimal(6,2) NOT NULL,
	isCountable decimal(1,0) DEFAULT 1,
	unit varchar(5) NOT NULL,
	basePrice decimal(6,2) NOT NULL,
	CONSTRAINT products_PK PRIMARY KEY(id)
);