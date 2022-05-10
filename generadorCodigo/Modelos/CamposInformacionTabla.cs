namespace generadorCodigo.Modelos
{
    public class CamposInformacionTabla
    {
        public string Table_Catalog { get; set; }
        public string Table_schema { get; set; }
        public string Table_name { get; set; }
        public string Column_name { get; set; }
        public int Ordinal_position { get; set; }
        public string Column_Default { get; set; }
        public string Is_nullable { get; set; }
        public string Data_type { get; set; }
        public int? Character_maximum_Length { get; set; }
        public int? Character_octet_length { get; set; }
        public int? Numeric_precision { get; set; }
        public int? Numeric_precision_radix { get; set; }
        public int? Numeric_Scale { get; set; }
        public int? Datetime_precision { get; set; }

    }
}
