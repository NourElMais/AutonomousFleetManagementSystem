namespace Fleet.API.Domain.Entities;

public class CoordinateTelemetry
{
    public string coord_x { get; set; }
    public string coord_y { get; set; }

    public CoordinateTelemetry(string coord_x, string coord_y)
    {
        this.coord_x = coord_x;
        this.coord_y = coord_y;
    }
}