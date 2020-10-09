INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Luis', 'Garsia', 'LuisGarcia@gmail.com', '1234', 1, '58745487');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Federico', 'Perez', 'fperez@gmail.com', '1234', 1, '57986532');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Belen', 'Curbelo', 'BeluCur@gmail.com', '1234', 1, '37879887');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Juan', 'Rodriguez', 'LuC31@gmail.com', '1234', 2, 'A1458');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Rodrigo', 'Guitierres', 'GuRodrigo@gmail.com', '1234', 1, '25468795');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Florencia', 'Noguera', 'FNog@gmail.com', '1234', 1, '58635474');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Christian', 'Perez', 'CHPerez@gmail.com', '1234', 1, '58635474');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Agustina', 'Diaz', 'AguDiaz2010@gmail.com', '1234', 1, '58635474');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Lucia', 'Perez', 'LuPerez@gmail.com', '1234', 2, 'B1587');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Karen', 'Garcia', 'KGarcia@gmail.com', '1234', 1, '58635474');

INSERT INTO usuario (id) VALUES (1);
INSERT INTO usuario (id) VALUES (2);
INSERT INTO usuario (id) VALUES (3);
INSERT INTO usuario (id) VALUES (4);
INSERT INTO usuario (id) VALUES (5);
INSERT INTO usuario (id) VALUES (6);
INSERT INTO usuario (id) VALUES (7);
INSERT INTO usuario (id) VALUES (8);
INSERT INTO usuario (id) VALUES (9);
INSERT INTO usuario (id) VALUES (10);

INSERT INTO admin (id) VALUES (4);
INSERT INTO admin (id) VALUES (5);

INSERT INTO conductor (id, vencimiento_libreta) VALUES (6, '02/07/2029');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (7, '06/05/2015');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (8, '15/01/2030');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (9, '25/11/2026');

INSERT INTO superadmin (id) VALUES (10);

INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MAB 5024', 'Mercedes', '1318', 25,NULL,NULL);
INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MBB 3243', 'Volvo', 'B430R', 35,NULL,NULL);
INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MAF 5344', 'Mercedes', '7 Ma', 30,NULL,NULL);
INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MDF 6543', 'MARCOPOLO', 'VIAGGIO 1050', 20,NULL,NULL);

INSERT INTO linea (nombre) VALUES ('San José - Montevidoe Directo');
INSERT INTO linea (nombre) VALUES ('San José - Montevidoe Semi Directo');
INSERT INTO linea (nombre) VALUES ('San José - Montevidoe Directisimo');
INSERT INTO linea (nombre) VALUES ('San José - Canelones Directo');
INSERT INTO linea (nombre) VALUES ('San José - Canelones Directisimo');

INSERT INTO parada (nombre, latitud, longitud) VALUES ('Terminal de Ómnibus San José de Mayo', -34.34006741034748, -56.714420781150324);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Parada de Rivera San José de Mayo', -34.34546638998191, -56.71956039944203);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Parada Libertad San José', -34.63780304762206, -56.61987469894831);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Plaza Cuba Montevideo', -34.8721766, -56.2027395);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Tres Cruces Montevideo', -34.893951222229404, -56.166246689410954);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Terminal de Ómnibus Santa Lucía', -34.4550929, -56.3893012);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Terminal de Ómnibus Canelones',  -34.622248, -55.99038);

INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,1,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (2,1,2,'00:05:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (3,1,3,'00:20:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (4,1,4,'00:20:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (5,1,5,'00:10:00')


INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,2,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (3,2,2,'00:35:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (5,2,3,'00:25:00')


INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,3,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (5,3,2,'00:50:00')


INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,4,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (6,4,2,'00:35:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (7,4,3,'00:25:00')


INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,5,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (7,5,2,'00:55:00')
-- Esto anda

-- Linea 1
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '09/10/2020',1,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (60, '09/10/2020',2,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (50, '09/06/2020',2,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (140, '19/10/2020',3,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (100, '19/04/2020',3,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (230, '19/10/2020',4,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (127, '01/02/2020',4,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (80, '19/10/2020',5,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (60, '30/04/2020',5,1);

-- Linea 2

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10/09/2020',1,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '10/09/2020',3,2);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (150, '01/05/2020',3,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (250, '10/09/2020',4,2);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '25/04/2020',4,2);

-- Linea 3

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10/10/2020',1,3);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (550, '10/10/2020',5,3);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (350, '25/03/2020',5,3);

-- Linea 4

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10/09/2020',1,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (300, '10/09/2020',6,4);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '11/04/2020',6,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (250, '10/09/2020',7,4);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (100, '25/05/2020',7,4);

-- Linea 5 

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10/10/2020',1,5);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (600, '10/10/2020',7,5);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (500, '11/13/2020',7,5);