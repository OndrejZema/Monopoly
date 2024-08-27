﻿namespace Monopoly.NewDAL.Entities;

public partial class Field
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long FieldTypeId { get; set; }
    public long GameId { get; set; }
    public Game Game { get; set; }
    public FieldType FieldType { get; set; }


}
