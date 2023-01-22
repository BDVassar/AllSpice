CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    recipes(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
        title VARCHAR(255) NOT NULL COMMENT 'Recipe Title',
        instructions VARCHAR(255) NOT NULL COMMENT 'Recipe Instructions',
        img VARCHAR(255) NOT NULL COMMENT 'Recipe Image',
        category VARCHAR(255) NOT NULL COMMENT 'Recipe Category',
        creatorId VARCHAR(255) NOT NULL COMMENT 'Creator Id',
        Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    ingredients(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL COMMENT 'Ingredient Name',
        quantity VARCHAR(255) NOT NULL COMMENT 'Ingredient Quantity',
        reciepeId INT NOT NULL COMMENT 'Reciepe Id',
        Foreign Key (reciepeId) REFERENCES recipes (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

    DROP TABLE ingredients;

CREATE TABLE
    favorites(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
        accountId VARCHAR(255) NOT NULL COMMENT 'account Id',
        recipeId INT NOT NULL COMMENT 'Reciepe Id',
        Foreign Key (accountId) REFERENCES accounts (id) ON DELETE CASCADE,
        Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

    INSERT INTO recipes
    (title, instructions, img, category, creatorId)
    VALUES
    ()