package com.bizruntime;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCache;
import org.apache.ignite.Ignition;

public class FirstProgram {
	public static void main(String[] args) {
		 
		// Set the node start mode as client; so, this node will join the apache
		// cluster as client
		Ignition.setClientMode(true);
 
		// Here, we provide the cache configuration file
		Ignite objIgnite = Ignition.start("F:\\softwares2\\apache-ignite-fabric-2.6.0-bin\\apache-ignite-fabric-2.6.0-bin\\config\\itc-poc-config.xml");
 
		// create cache if not already existing
		IgniteCache<Integer, String> objIgniteCache = objIgnite.getOrCreateCache("myFirstIgniteCache");
 
		// Populating the cache with few values
		objIgniteCache.put(1, "Anji");
		objIgniteCache.put(2, "Abhishek");
		objIgniteCache.put(3, "Siddharth");
		objIgniteCache.put(4, "Dev");
 
		// Get these items from cache
		System.out.println(objIgniteCache.get(1));
		System.out.println(objIgniteCache.get(2));
		System.out.println(objIgniteCache.get(3));
		System.out.println(objIgniteCache.get(4));
	}
}
