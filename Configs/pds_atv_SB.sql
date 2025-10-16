create database pds_atv_SB;
use pds_atv_SB;

# PRODUTO - Mazzie
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

# INGREDIENTES - MAZZIE
CREATE TABLE ingredientes (
    id_ing int not null primary key auto_increment,
    nome_ing VARCHAR(255) NOT NULL,
    quantidade_ing INT NOT NULL,
    descricao_ing VARCHAR(255)
  );
insert into ingredientes values (null, 'leite', 15, 'frios');
insert into ingredientes values (null, 'manteiga', 1, 'frios');
insert into ingredientes values (null, 'sal', 12,'comida');
insert into ingredientes values (null, 'açucar', 35, 'comida');
insert into ingredientes values (null, 'trigo', 57, 'comida');


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
cpf_func varchar(100),
cep_func varchar(100)
);
alter table funcionarios change cpf_func cpf_func varchar (300);

insert into funcionarios values (null, 'Maria', 'cozinheira', '1988-10-30', 'maria@gmail.com', '69 84111155', '123.544.311-99', '76900345');
insert into funcionarios values (null, 'Joana', 'boleira', '1965-1-20', 'joana@gmail.com', '11 454546511',  '565.888.988-88', '54656698');
insert into funcionarios values (null, 'Miguel', 'entregador', '1990-05-23', 'miguel@gmail.com', '69 5555 4444', '998.999.789-55', '5465623'); 

# CLIENTE - Stuart
CREATE TABLE 
  cliente (
  id_cli INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  nome_cli VARCHAR (255) NOT NULL,
  telefone_cli VARCHAR (15),
  email_cli VARCHAR (255),
  cidade_cli VARCHAR (255),
  estado_cli VARCHAR (255)
  );

INSERT INTO cliente VALUES ('1', 'Gabriel Oliveira', '11987654321', 'gabriel@gmail.com', 'São Paulo', 'SP');
INSERT INTO cliente VALUES ('2', 'Camila Costa', '21991234567', 'camila.costa@yahoo.com', 'Rio de Janeiro', 'RJ');
INSERT INTO cliente VALUES ('3', 'Larissa Ferreira', '31999887766', 'larissa.ferreira@outlook.com', 'Belo Horizonte', 'MG');
INSERT INTO cliente VALUES ('4', 'Isadora Bellucci', '41998765432', 'isadora.bellucci@gmail.com', 'Curitiba', 'PR');
INSERT INTO cliente VALUES ('5', 'Sofia Cantarini', '51997654321', 'sofia.cantarini@hotmail.com', 'Porto Alegre', 'RS');

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
create table recebimento(
id_receb int not null primary key auto_increment,
pedido_receb varchar(100) not null,
valor_receb decimal (10,2) not null,
formaPag_receb varchar (50) not null,
comprovante_receb varchar(100),
cliente_receb varchar(100) not nulL
);

insert into recebimento values ('1', 'vatapa', '20.00', 'pix', 'transferido', 'Matheus Silva');
insert into recebimento values ('2', 'pão de forma', '12.00','cartão', 'transferido', 'Luana Ribeiro');
insert into recebimento values ('3', 'salpicão', '15.00', 'Dinheiro', 'tranferido', 'Maria Luiza Motta');
insert into recebimento values ('4', 'feijoada', '25.00', 'Dinheiro', 'transferido', 'Douglas Purubora');
insert into recebimento values ('5', 'arroz tropeiro', '10.00', 'pix', 'tranferido', 'Maryanna Souza');

create table notificacao(
  id_noti int not null primary key auto_increment,
  numero_pedido_noti int,
  nome_cliente_noti varchar (500),
  status_noti varchar (50) not null,
  total_noti decimal (10, 2) not null
  );

insert into notificacao values ('1', '20', 'Lucas', 'Em análise', '3.00');
insert into notificacao values ('2', '7', 'Ricardo', 'Pagamento Reprovado', '10');
insert into notificacao values ('3', '1', 'Maryanna', 'Aguardando Transição', '19');
insert into notificacao values ('4', '6', 'Júlia', 'Pagamento recusado', '3');
insert into notificacao values ('5', '2', 'Flávia', 'Pagamento Aprovado', '2');