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

INSERT INTO conductor (id, vencimiento_libreta) VALUES (6, '02-07-2029');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (7, '06-05-2015');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (8, '15-01-2030');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (9, '25-01-2026');

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

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '09-10-2020',1,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (60, '09-10-2020',2,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (50, '09-06-2020',2,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (140, '19-10-2020',3,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (100, '19-04-2020',3,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (230, '19-10-2020',4,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (127, '01-02-2020',4,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (80, '19-10-2020',5,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (60, '30-04-2020',5,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10-09-2020',1,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '10-09-2020',3,2);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (150, '01-05-2020',3,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (250, '10-09-2020',5,2);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '25-04-2020',5,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10-10-2020',1,3);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (550, '10-10-2020',5,3);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (350, '25-03-2020',5,3);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10-09-2020',1,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (300, '10-09-2020',6,4);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '11-04-2020',6,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (250, '10-09-2020',7,4);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (100, '25-05-2020',7,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '10-10-2020',1,5);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (600, '10-10-2020',7,5);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (500, '11-13-2020',7,5);
 
--p Horario conductores:6,7,8,9 -Veiculos: 1,2,3,4 -linea: 1,2,3,4,5
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('05:00:00',6,1,1);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('09:00:00',6,1,2);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('14:00:00',6,1,3);


INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('07:00:00',7,2,4);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('10:30:00',7,2,5);


INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('15:00:00',8,3,1);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('19:00:00',8,3,2);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('20:00:00',8,3,3);


INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('12:00:00',9,4,4);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('18:00:00',9,4,5);


INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('10-10-2020', 1, 1);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('11-09-2020', 0, 2);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('09-10-2020', 1, 3);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('12-09-2020', 1, 4);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('14-08-2020', 1, 5);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('20-10-2020', 0, 6);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('01-05-2020', 1, 7);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('10-10-2020', 1, 8);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('19-08-2020', 1, 9);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('10-11-2020', 0, 10);

	
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 2, '10-10-2020 05:05:22');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 3, '10-10-2020 05:30:58');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 4, '10-10-2020 05:45:45');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 5, '10-10-2020 06:05:45');

INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (2, 3, '11-09-2020 09:36:48');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (2, 5, '11-09-2020 10:03:57');
	
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (3, 4, '09-10-2020 14:45:05');

INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (4, 3, '12-09-2020 07:36:08');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (4, 5, '12-09-2020 07:56:17');
	
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (5, 2, '14-08-2020 11:02:12');

INSERT INTO pasaje (id, asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (1, 15, 1, NULL, NULL, 1, 2, 1, 5);

INSERT INTO pasaje (id, asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (2, 25, 1, 1,'78459658', NULL, 2, 1, 3);

INSERT INTO pasaje (id, asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (3, 20, 0, NULL, NULL, 2, 6, 2, 5);

INSERT INTO pasaje (id, asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (4, 10, 0, NULL, NULL, 3, 6, 2, 4);

INSERT INTO pasaje (id, asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (5, 13, 0, NULL, NULL, 4, 6, 2, 5);

INSERT INTO pasaje (id, asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (6, 16, 0, NULL, NULL, 5, 6, 3, 5);

