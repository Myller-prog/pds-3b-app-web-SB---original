create database pds_atv_SB;
use pds_atv_SB;

# PRODUTO - Mazzye
CREATE TABLE produto (
    id_pro int not null primary key auto_increment,
    nome_pro VARCHAR(255) NOT NULL,
    quantidade_pro INT NOT NULL,
    descricao_pro VARCHAR(255),
    preco_pro DECIMAL(10, 2) NOT NULL
  );
insert into produto values (null, 'vatapá', 15, 'comida', '15.00');
insert into produto values (null, 'pão caseiro', 12, 'pão caseiro', '12.00');
insert into produto values (null, 'coxinha', 12,'comida', '5.00');
insert into produto values (null, 'lasanha', 25, 'comida', '16.00');
insert into produto values (null, 'frango assado', 40, 'comida', '10.00');

# ALIMENTO - Max

create table alimento (
id_ali int not null primary key auto_increment,
nome_ali varchar (200) not null,
tipo_ali varchar (200),
valor_ali int,
ingrediente_ali varchar (200)
);

insert into alimento values (null, 'não', 'Laticinio', '15.00', 'leite');
insert into alimento values (null, 'pão', 'carboidrato', '12.00', 'leite, ovos, trigo...');
insert into alimento values (null, 'torta', 'carboidrato', '14.00', 'frango, leite, ovos...');

# FUNCIONÁRIO - Max

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

# CLIENTE - Stuart

# PEDIDO - Stuart

CREATE TABLE 
  pedido (
  id_ped INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  NomeCliente VARCHAR (255) NOT NULL,
  forma_pagamento VARCHAR (15),
  numero_pedido VARCHAR (15),
  status_ped VARCHAR (255)
  );
  alter table pedido add column total decimal;

INSERT INTO pedido VALUES (null,'Madalena', 'Pendente', 'Pix', 'n 1', '7.00');
INSERT INTO pedido VALUES (null, 'Ana Souza', 'Pronto', 'Dinheiro', 'n 3', '50.00');

# RECEBIMENTO - Thauane








