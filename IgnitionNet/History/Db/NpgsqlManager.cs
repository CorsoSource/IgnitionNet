using Microsoft.EntityFrameworkCore;

namespace CorsoSystems.IgnitionNet.History.Db
{
    /// <summary>
    /// Requires Postgres (9.5+) for "CREATE IF NOT EXISTS"
    /// </summary>
    sealed class NpgsqlManager : AbstractDbManager
    {
		public NpgsqlManager(DbContext context) : base(context)
		{
		}

		public override string PatchAlarmEventData => @"
			CREATE TABLE IF NOT EXISTS public.alarm_event_data (
				id int4 NULL,
				propname varchar(255) NULL,
				dtype int4 NULL,
				intvalue int8 NULL,
				floatvalue float8 NULL,
				strvalue text NULL
			);
			CREATE INDEX IF NOT EXISTS alarm_event_dataidndx ON public.alarm_event_data USING btree (id);";

		public override string PatchAlarmEvents => @"
			CREATE TABLE IF NOT EXISTS public.alarm_events (
				id serial4 NOT NULL,
				eventid varchar(255) NULL,
				""source"" varchar(255) NULL,
				displaypath varchar(255) NULL,
				priority int4 NULL,
				eventtype int4 NULL,
				eventflags int4 NULL,
				eventtime timestamp NULL,
				CONSTRAINT alarm_events_pkey PRIMARY KEY(id)
			);";

        public override string PatchHistoricalTagAnnotations => @"
			CREATE TABLE IF NOT EXISTS public.sqlth_annotations (
				id serial4 NOT NULL,
				tagid int4 NULL,
				start_time int8 NULL,
				end_time int8 NULL,
				""type"" varchar(255) NULL,
				datavalue varchar(255) NULL,
				annotationid varchar(255) NULL,
				CONSTRAINT sqlth_annotations_pkey PRIMARY KEY(id)
			);
			CREATE INDEX IF NOT EXISTS sqlth_annotationsend_timendx ON public.sqlth_annotations USING btree(end_time);
			CREATE INDEX IF NOT EXISTS sqlthannotationsstarttimendx ON public.sqlth_annotations USING btree(start_time);";

        public override string PatchHistoricalDriver => @"
			CREATE TABLE IF NOT EXISTS public.sqlth_drv (
				id serial4 NOT NULL,
				""name"" varchar(255) NULL,
				provider varchar(255) NULL,
				CONSTRAINT sqlth_drv_pkey PRIMARY KEY(id)
			);";

        public override string PatchHistoricalScanClassExecution => @"
			CREATE TABLE IF NOT EXISTS public.sqlth_sce (
				scid int4 NULL,
				start_time int8 NULL,
				end_time int8 NULL,
				rate int4 NULL
			);
			CREATE INDEX IF NOT EXISTS sqlth_sceend_timendx ON public.sqlth_sce USING btree (end_time);
			CREATE INDEX IF NOT EXISTS sqlth_scestart_timendx ON public.sqlth_sce USING btree (start_time);";

        public override string PatchHistoricalScanClass => @"
			CREATE TABLE IF NOT EXISTS public.sqlth_scinfo (
				id serial4 NOT NULL,
				scname varchar(255) NULL,
				drvid int4 NULL,
				CONSTRAINT sqlth_scinfo_pkey PRIMARY KEY (id)
			);";

        public override string PatchHistoricalTag => @"
			CREATE TABLE IF NOT EXISTS public.sqlth_te (
				id serial4 NOT NULL,
				tagpath varchar(255) NULL,
				scid int4 NULL,
				""datatype"" int4 NULL,
				querymode int4 NULL,
				created int8 NULL,
				retired int8 NULL,
				CONSTRAINT sqlth_te_pkey PRIMARY KEY(id)
			);
			CREATE INDEX IF NOT EXISTS sqlth_tetagpathndx ON public.sqlth_te USING btree(tagpath);";

		public override string PatchPartition(string partitionName)
		{
            var tableName = $"public.{partitionName}";
            var pkName = $"{partitionName}_pkey";
            var idxName = $"{partitionName}tstampndx";
			
            return $@"
                CREATE TABLE IF NOT EXISTS {tableName} (
                    tagid int4 NOT NULL,
                    intvalue int8 NULL,
                    floatvalue float8 NULL,
                    stringvalue varchar(255) NULL,
                    datevalue timestamp NULL,
                    dataintegrity int4 NULL,
                    t_stamp int8 NOT NULL,
                    CONSTRAINT {pkName} PRIMARY KEY (tagid, t_stamp)
                );
                CREATE INDEX IF NOT EXISTS {idxName} ON {tableName} USING btree (t_stamp);";
        }
	}
}
