﻿using NLog;
using System;

namespace AutoClose
{
    public class NLog
    {
        private static Logger _logger;

        static NLog()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        #region Debug
        public static void Debug(string msg, params object[] args)
        {
            _logger.Debug(msg, args);
        }

        public static void Debug(string msg, Exception err)
        {
            _logger.Debug(err, msg);
        }
        #endregion

        #region Info
        public static void Info(string msg)
        {
            _logger.Info(msg);
        }
        #endregion

        #region Warn
        public static void Warn(string msg, params object[] args)
        {
            _logger.Warn(msg, args);
        }

        public static void Warn(string msg, Exception err)
        {
            _logger.Warn(err, msg);
        }
        #endregion

        #region Trace
        public static void Trace(string msg, params object[] args)
        {
            _logger.Trace(msg, args);
        }

        public static void Trace(string msg, Exception err)
        {
            _logger.Trace(err, msg);
        }
        #endregion

        #region Error
        public static void Error(string msg, params object[] args)
        {
            _logger.Error(msg, args);
        }

        public static void Error(string msg, Exception err)
        {
            _logger.Error(err, msg);
        }
        #endregion

        #region Fatal
        public static void Fatal(string msg, params object[] args)
        {
            _logger.Fatal(msg, args);
        }

        public static void Fatal(string msg, Exception err)
        {
            _logger.Fatal(err, msg);
        }
        #endregion
    }
}