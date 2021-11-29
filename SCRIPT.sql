create database db_RESTAURANTE;

use db_RESTAURANTE;

create table tbl_Cliente
(
	cd_Cliente int auto_increment,
    nm_Cliente varchar(80) not null,
    ds_Email varchar(80) not null,
 /*   nm_Logradouro varchar(80) not null,
    no_Logradouro varchar(5) not null,
    ds_Complemento varchar(30),
    nm_Bairro varchar(20) not null, */
    primary key (cd_Cliente)
);

UPDATE tbl_Cliente SET  nm_Cliente = 'Gabriella',  ds_Email = 'gabimatias@gmail.com'  WHERE cd_Cliente = 9;
insert into tbl_Cliente( nm_Cliente, ds_Email)
values("Claudia","claudia123@gmail.com");

select * from tbl_cliente;

create table tbl_Telefone
(
	cd_Cliente int,
    no_Telefone char(11),
    constraint primary key (cd_Cliente, no_Telefone),
    constraint fk_Cliente foreign key(cd_Cliente) references tbl_Cliente(cd_Cliente)
);

select * from tbl_telefone;

create table tbl_Reserva
(
	cd_Reserva int auto_increment,
    hr_Reserva timestamp default current_timestamp,
    dt_Reserva date,
    hr_Uso time, 
    primary key (cd_Reserva),
    cd_Cliente int,
    constraint fk_Cli foreign key(cd_Cliente) references tbl_Cliente(cd_Cliente)
);

select * from tbl_Reserva;

create table tbl_Mesa
(
	cd_Mesa int auto_increment,
    primary key(cd_Mesa)
);

select * from tbl_Mesa;

create table tbl_Funcionario
(
	cd_Func int auto_increment,
    nm_Func varchar(80),
    ds_Login varchar(20),
    ds_Senha varchar(5),
    no_Telefone varchar(11),
    primary key(cd_Func)
);

select * from tbl_Funcionario;

create table tbl_Cargo
(
	cd_Cargo int auto_increment, 
    nm_Cargo varchar(20),
    vl_Salario decimal(10,2),
    primary key (cd_Cargo)
);

select * from tbl_Cargo;

create table tbl_Categoria
(
	cd_Categoria int auto_increment,
    nm_Categoria varchar(20),
    primary key (cd_Categoria)
);

select * from tbl_categoria;

create table tbl_Cardapio
(
	cd_Cardapio int auto_increment,
    vl_Cardapio decimal(10,2),
    ds_Cardapio varchar(200), 
    cd_Categoria int,
    constraint fk_Cat foreign key(cd_Categoria) references tbl_Categoria (cd_Categoria),
    primary key (cd_Cardapio)
);

create table tbl_Delivery
(
	cd_Delivery int auto_increment,
	horaVenda timestamp default current_timestamp,
	dataEntrega DATE,
    primary key (cd_Delivery)
);

select * from tbl_delivery;

create table tbl_Pedido
(
	cd_Pedido int auto_increment,
    dt_Pedido date,
    vl_TotalPedido decimal(10,2),
    ds_Status char(1), 
    cd_Delivery int,
    constraint fk_Del foreign key(cd_Delivery) references tbl_Delivery (cd_Delivery),
    cd_Func int, 
    constraint fk_Func foreign key(cd_Func) references tbl_Funcionario (cd_Func),
    cd_Cliente int,
    constraint fk_Client foreign key(cd_Cliente) references tbl_Cliente (cd_Cliente),
    cd_Mesa int,
    constraint fk_Mesa foreign key(cd_Mesa) references tbl_Mesa (cd_Mesa),
    primary key (cd_Pedido)
);

select * from tbl_pedido;

create table tbl_Pagamento
(
	cd_Pagto int auto_increment,
    ds_Pagto varchar(20),
	primary key (cd_Pagto)
);

select * from tbl_Pagamento;

create table tbl_Venda
(
	cd_Venda int auto_increment,
    dt_Venda date,
    cd_Pagto int,
    constraint fk_Pgt foreign key(cd_Pagto) references tbl_Pagamento (cd_Pagto),
    primary key (cd_Venda)
);

select * from tbl_Venda;


create table Itens_Pedido
(
	cd_Cardapio int,
    cd_Pedido int,
    vl_Unitario decimal(10,2),
    qt_Itens int not null,
    primary key (cd_Pedido, cd_Cardapio),
	constraint foreign key(cd_Pedido) references tbl_Pedido (cd_Pedido),
    constraint foreign key(cd_Cardapio) references tbl_Cardapio (cd_Cardapio)
);

select * from Itens_Pedido;

