﻿using etl_job_service.Config;

namespace etl_job_service.Repository
{
    /**
     * @abstract
     * BaseRepository
     * 
     * This class contains the base of the repository that mainly functioning for Dependency Injection.
     */ 
    public abstract class BaseRepository
    {
        protected readonly DatabaseContext _context;
        public BaseRepository(DatabaseContext context) { this._context = context; }
    }
}
