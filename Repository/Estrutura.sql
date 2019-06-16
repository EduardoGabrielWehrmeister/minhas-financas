DROP TABLE contaspagar
CREATE TABLE contaspagar(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100),
valor DECIMAL(10,2),
tipo VARCHAR(50),
descricao VARCHAR(300),
status VARCHAR(50),
);

DROP TABLE contasreceber
CREATE TABLE contasreceber(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100),
valor DECIMAL(10,2),
tipo VARCHAR(100),
descricao VARCHAR(300),
status VARCHAR(50),
);


