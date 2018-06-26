using System;

public interface IModel
{
    int Id { get; set; }
    DateTime Updated { get; set; }
    DateTime Created { get; set; }
}