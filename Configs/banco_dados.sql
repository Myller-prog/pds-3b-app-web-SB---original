create database pds_atv_SB;
use pds_atv_SB;

CREATE TABLE
  fornecedor (
    id_for INT NOT NULL AUTO_INCREMENT,
    nome_for VARCHAR(255) NOT NULL,
    PRIMARY KEY (id_for)
  );

CREATE TABLE
  produto (
    id_pro INT NOT NULL AUTO_INCREMENT,
    id_for_fk INT NULL,
    nome_pro VARCHAR(255) NOT NULL,
    descricao_pro TEXT NULL,
    quantidade_pro INT NOT NULL,
    preco_pro DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id_pro),
    FOREIGN KEY (id_for_fk) REFERENCES fornecedor (id_for)
  );

-- Inserindo fornecedores
INSERT INTO
  fornecedor (nome_for)
VALUES
  ('Fornecedor Alpha'),
  ('Fornecedor Beta'),
  ('Fornecedor Gamma'),
  ('Fornecedor Delta');

-- Inserindo produtos vinculados aos fornecedores
INSERT INTO
  produto (
    id_for_fk,
    nome_pro,
    descricao_pro,
    quantidade_pro,
    preco_pro
  )
VALUES
  (
    1,
    'Notebook X',
    'Notebook de alto desempenho com 16GB RAM e SSD 512GB',
    10,
    4500.00
  ),
  (
    1,
    'Mouse Óptico',
    'Mouse com fio, 1200 DPI',
    50,
    45.90
  ),
  (
    2,
    'Smartphone Y',
    'Smartphone 6.5 polegadas, 128GB',
    20,
    2100.00
  ),
  (
    2,
    'Carregador Rápido',
    'Carregador USB-C 25W',
    100,
    89.90
  ),
  (
    3,
    'Cadeira Gamer',
    'Cadeira ergonômica ajustável',
    15,
    1250.00
  ),
  (
    3,
    'Mesa de Escritório',
    'Mesa em L com suporte para monitor',
    8,
    980.00
  ),
  (
    4,
    'Monitor 27"',
    'Monitor LED Full HD 27 polegadas',
    12,
    1150.00
  ),
  (
    4,
    'Teclado Mecânico',
    'Teclado RGB switch blue',
    30,
    350.00
  );
  
create table alimento (
id_ali int not null primary key auto_increment,
nome_ali varchar (200) not null,
tipo_ali varchar (200),
valor_ali int,
ingrediente_ali varchar (200)
);

insert into alimento values (null, 'iorgute', 'Laticinio', '15.00', 'leite');
insert into alimento values (null, 'pão', 'carboidrato', '12.00', 'leite, ovos, trigo...');
insert into alimento values (null, 'torta', 'carboidrato', '14.00', 'frango, leite, ovos...');

create table funcionarios (
id_func int not null primary key auto_increment,
nome_func varchar (200),
cargo_func varchar (200),
dataNasc_func varchar (200),
email_func varchar (200),
telefone_func varchar (200),
cpf_func int,
cep_func int
);
alter table funcionarios change cpf_func cpf_func varchar (300);

insert into funcionarios values (null, 'Maria', 'cozinheira', '1988-10-30', 'maria@gmail.com', '69 84111155', '123.544.311-99', '76900345');
insert into funcionarios values (null, 'Joana', 'boleira', '1965-1-20', 'joana@gmail.com', '11 454546511',  '565.888.988-88', '54656698');
insert into funcionarios values (null, 'Miguel', 'entregador', '1990-05-23', 'miguel@gmail.com', '69 5555 4444', '998.999.789-55', '5465623'); 







