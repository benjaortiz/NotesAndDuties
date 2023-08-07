using NotesAndDutiesAPI;

namespace Services.DutiesService;

public class DutiesService {
    
    private IDutiesRepository _duties;

    public DutiesService(IDutiesRepository duties){
        _duties = duties;
    }
}