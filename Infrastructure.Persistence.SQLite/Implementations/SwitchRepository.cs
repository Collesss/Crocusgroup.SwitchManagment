using MapsterMapper;

namespace Infrastructure.Persistence.SQLite.Implementations
{
    public class SwitchRepository
    {
        private readonly SQLiteDbContext _dbContext;
        private readonly IMapper _mapper;

        public SwitchRepository(SQLiteDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
