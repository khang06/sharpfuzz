using System;
using System.Runtime.InteropServices;

namespace SharpFuzz
{
	// Interop methods for attaching/detaching shared memory segments.
	public static class Native
	{
		[DllImport("ld_preload_fuzz", SetLastError = true)]
		public static extern SharedMemoryHandle shmat(int shmid, IntPtr shmaddr, int shmflg);

		[DllImport("ld_preload_fuzz", SetLastError = true)]
		public static unsafe extern int read(int fd, byte* buffer, int count);

		[DllImport("libc", SetLastError = true)]
		public static extern int shmdt(IntPtr shmaddr);

		[DllImport("ld_preload_fuzz", SetLastError = true)]
		public static extern void fast_exit();

		[DllImport("ld_preload_fuzz", SetLastError = true)]
		public static extern void nyx_init();
	}
}
