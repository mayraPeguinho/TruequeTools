﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Usuario" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("usuarios")]

    public class Usuario
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO

        [Column("nombre")]
        [MaxLength(50)]
        public required string Nombre { get; set; }

        [Column("apellido")]
        [MaxLength(50)]
        public required string Apellido { get; set; }

        [Column("email")]
        [MaxLength(50)]
        public required string Email { get; set; }

        [Column("contraseña")]
        [MaxLength(50)]
        public required string Contraseña { get; set; }

        [Column("fechaNacimiento")]
        public required DateOnly FechaNacimiento { get; set; }

        //METADATA

        [Column("rol")]
        [MaxLength(50)]
        public string Rol { get; set; } = "User";

        //CLAVE EXTERNA USUARIO -> SUCURSAL

        [Column("sucursalId")]
        public int SucursalId { get; set; }

        //ATRIBUTOS NO SQL

        public Sucursal? Sucursal { get; set; }
        public ICollection<Publicacion>? Publicaciones { get; set; }

    }

}
