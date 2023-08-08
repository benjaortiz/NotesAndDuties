using NotesAndDutiesAPI;

namespace Services.DutiesService;

public class DutiesService : IDutiesService {
    
    private IDutiesRepository _duties;

    public DutiesService(IDutiesRepository duties){
        _duties = duties;
    }
}