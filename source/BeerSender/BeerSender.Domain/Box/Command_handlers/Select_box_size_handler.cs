namespace BeerSender.Domain.Box;

public class Select_box_size_handler : Command_handler<Select_box_size, Box> 
{
    public Select_box_size_handler(Func<Guid, IEnumerable<object>> event_stream, Action<Guid, object> publish_event) : base(event_stream, publish_event)
    {
    }
    
    public override IEnumerable<object> Handle_command(Box aggregate, Select_box_size command)
    {
        try
        {
            var size = new Box_size(command.Number_of_bottles);
            return new [] {new Box_selected(size)};
        }
        catch (BoxException ex)
        {
            return new[] { new Box_failed_to_select_box(ex) };
        }
    }
}