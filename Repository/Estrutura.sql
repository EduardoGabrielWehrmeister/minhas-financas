DROP TABLE contas_pagar
CREATE TABLE contas_pagar(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100),
valor DECIMAL(10,2),
tipo VARCHAR(50),
descricao VARCHAR(300),
status VARCHAR(50),
);

DROP TABLE contas_receber
CREATE TABLE contas_receber(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100),
valor DECIMAL(10,2),
tipo VARCHAR(100),
descricao VARCHAR(300),
status VARCHAR(50),
);

DROP TABLE pessoas_fisicas
CREATE TABLE pessoas_fisicas(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100),
cpf VARCHAR(15),
data_nascimento DATETIME2,
rg VARCHAR(30),
sexo VARCHAR(100),
);



