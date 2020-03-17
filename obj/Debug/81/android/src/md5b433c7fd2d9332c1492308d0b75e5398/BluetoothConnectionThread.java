package md5b433c7fd2d9332c1492308d0b75e5398;


public class BluetoothConnectionThread
	extends java.lang.Thread
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler\n" +
			"";
		mono.android.Runtime.register ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", BluetoothConnectionThread.class, __md_methods);
	}


	public BluetoothConnectionThread ()
	{
		super ();
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "", this, new java.lang.Object[] {  });
	}


	public BluetoothConnectionThread (java.lang.Runnable p0)
	{
		super (p0);
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "Java.Lang.IRunnable, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BluetoothConnectionThread (java.lang.Runnable p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "Java.Lang.IRunnable, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public BluetoothConnectionThread (java.lang.String p0)
	{
		super (p0);
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public BluetoothConnectionThread (java.lang.ThreadGroup p0, java.lang.Runnable p1)
	{
		super (p0, p1);
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "Java.Lang.ThreadGroup, Mono.Android:Java.Lang.IRunnable, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BluetoothConnectionThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2)
	{
		super (p0, p1, p2);
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "Java.Lang.ThreadGroup, Mono.Android:Java.Lang.IRunnable, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BluetoothConnectionThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2, long p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "Java.Lang.ThreadGroup, Mono.Android:Java.Lang.IRunnable, Mono.Android:System.String, mscorlib:System.Int64, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public BluetoothConnectionThread (java.lang.ThreadGroup p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "Java.Lang.ThreadGroup, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

	public BluetoothConnectionThread (android.bluetooth.BluetoothDevice p0)
	{
		super ();
		if (getClass () == BluetoothConnectionThread.class)
			mono.android.TypeManager.Activate ("Bluetooth.Plugin.Android.BluetoothConnectionThread, Plugin.Bluetooth", "Android.Bluetooth.BluetoothDevice, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
