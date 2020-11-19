using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ProjectLocationToMap : FsmStateAction
	{
		public enum MapProjection
		{
			EquidistantCylindrical = 0,
			Mercator = 1,
		}

		public FsmVector3 GPSLocation;
		public MapProjection mapProjection;
		public FsmFloat minLongitude;
		public FsmFloat maxLongitude;
		public FsmFloat minLatitude;
		public FsmFloat maxLatitude;
		public FsmFloat minX;
		public FsmFloat minY;
		public FsmFloat width;
		public FsmFloat height;
		public FsmFloat projectedX;
		public FsmFloat projectedY;
		public FsmBool normalized;
		public bool everyFrame;
	}
}
