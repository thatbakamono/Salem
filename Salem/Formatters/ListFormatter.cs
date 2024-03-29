﻿using System.Collections;

namespace Salem.Formatters
{
    [Formatter(typeof(IList))]
    public class ListFormatter : IFormatter
    {
        private ILogger _logger;

        public ListFormatter(ILogger logger)
        {
            _logger = logger;
        }

        public void Format(string loglevel, object input)
        {
            var list = (IList)input;

            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                    _logger.Log("", "  " + list[i], _logger.Scope);
                else
                    _logger.Log(loglevel, list[i], _logger.Scope);
            };
        }
    }
}