using UnityEngine.Events;

namespace CreateNeptune
{
	public class SaveDataLoadedEvent : UnityEvent
	{
		public static SaveDataLoadedEvent Instance = new SaveDataLoadedEvent();
	}
}
