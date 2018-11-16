package com.bizruntime;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCache;
import org.apache.ignite.Ignition;
import org.apache.ignite.configuration.IgniteConfiguration;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class SpringIgniteRun {
	public static void main(String[] args) throws Exception{
        System.out.println("Run Spring example!!");
        ApplicationContext ctx = new ClassPathXmlApplicationContext("spring-core.xml");

        IgniteConfiguration igniteConfiguration = (IgniteConfiguration) ctx.getBean("ignite.cfg");
        Ignite ignite = Ignition.start(igniteConfiguration);
        // get or create cache
        IgniteCache cache = ignite.getOrCreateCache("myCacheName");
        for(int i = 1; i < 1000; i++){
            cache.put(i, Integer.toString(i));
        }
        for(int i =1; i<1000;i++){
            System.out.println("Cache get:"+ cache.get(i));
        }
        Thread.sleep(20000); // sleep for 20 seconds
        // statistics
        System.out.println("Cache Hits:"+ cache.metrics(ignite.cluster()).getCacheHits());
        ignite.close();
	}
}
