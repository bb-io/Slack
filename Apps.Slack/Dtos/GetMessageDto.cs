using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Dtos
{
    public class GetMessageDto<T>
    {
        public IEnumerable<FileMessageDto> Messages { get; set; }
    }

    public class FileMessageDto
    {
        public string Text { get; set; }

        public IEnumerable<FileInfoDto> Files { get; set; }
    }
}
