using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Networking.DTOs
{
    public class ApplyJobDTO
    {
        public long userId { get; set; }
        public long jobId { get; set; }

        public ApplyJobDTO(long jobId, long userId)
        {
            this.jobId = jobId;
            this.userId = userId;
        }

    }
}
