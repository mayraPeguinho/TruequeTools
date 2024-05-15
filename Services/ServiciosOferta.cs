﻿using Microsoft.EntityFrameworkCore;
using TruequeTools.Data;
using TruequeTools.Entities;

/*

Esta clase implementa los servicios que establece la interfaz "InterfazServiciosOferta"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Producto"

*/

namespace TruequeTools.Services
{
    public class ServiciosOferta(TruequeToolsDataContext context) : IServiciosOferta
    {

        private readonly TruequeToolsDataContext contexto = context;

        //RECIBE UNA OFERTA COMO PARAMETRO Y LA AGREGA A LA BASE DE DATOS
        public async Task CreateOferta(Oferta oferta)
        {
            contexto.Ofertas.Add(oferta);
            await contexto.SaveChangesAsync();
        }

        //DEVUELVE UNA LISTA CON TODAS LAS OFERTAS DE LA BASE DE DATOS
        public async Task<List<Oferta>> ReadAllOfertas()
        {
            var result = await contexto.Ofertas.ToListAsync();
            return result;
        }

        //DEVUELVE UNA LISTA CON TODAS LAS OFERTAS DEL USUARIO QUE SE PASA COMO PARAMETRO
        public async Task<List<Oferta>> ReadAllOfertasCurrentUser(int userId)
        {
            var ofertas = await (from o in contexto.Ofertas join p in contexto.Publicaciones on o.PublicacionId equals p.Id join u in contexto.Usuarios on p.UsuarioId equals userId select o).ToListAsync();
            return ofertas;
        }

    }

}
