CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS trips (
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  notes TEXT,
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId)
    REFERENCES accounts(id)
    ON DELETE CASCADE

) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS reservations (
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  category ENUM ('flight', 'car', 'hotel', 'entertainment', 'other'),
  date VARCHAR(255) NOT NULL,
  confirmationCode VARCHAR(255) NOT NULL,
  cost DECIMAL(8, 2) DEFAULT 0,
  address VARCHAR(255),
  tripId INT NOT NULL,

  FOREIGN KEY (tripId)
    REFERENCES trips(id)
    ON DELETE CASCADE
)