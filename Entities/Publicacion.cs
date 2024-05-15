﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Publicacion" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("publicaciones")]

    public class Publicacion
	{

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO

        [Column("titulo")]
        [MaxLength(50)]
        public string? Titulo { get; set; }

        //METADATA

        [Column("isPremium")]
        public bool IsPremium { get; set; } = false;

        [Column("isOculta")]
        public bool IsOculta { get; set; } = false;

        [Column("fechaPublicacion")]
        public DateOnly FechaPublicacion { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //CLAVE EXTERNA USUARIO

        [Column("usuarioId")]
        public int UsuarioId { get; set; }

        //CLAVE EXTERNA SUCURSAL

        [Column("sucursalId")]
        public int SucursalId { get; set; }

        //ATRIBUTOS NO SQL

        public Usuario? Usuario { get; set; }
        public Sucursal? Sucursal { get; set; }
        public Producto? Producto { get; set; }
        public List<Pregunta>? Preguntas { get; set; }
		public List<Oferta>? Ofertas { get; set; }

	}

}
