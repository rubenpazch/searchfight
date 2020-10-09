using System;

namespace Views
{
    public interface ISearchFightView
    {
        void RenderError(string message);

        void RenderMessage(string message);
        void RenderSearchAndFightData();
    }
}
