'use client'
import React, { useState} from "react"
import { UserCircleIcon } from "@heroicons/react/24/solid"
import axios from "axios"
import { useSession } from "next-auth/react"

// const session?.data? = {
//     fullname: 'Iweene Wanjiru',
//     username: 'Iweene',
//     email: 'Iweene@gmail.com',

// }
export default function Page() {
    const [data, setData] = useState()
    const session = useSession();

    return(
        <div className="flex flex-row mt-10 md:flex-row">
            <h1 className="text-pink-900 font-bold text-2xl md:text-lg ml-9">Welcome back {session?.data?.fullName}</h1>
            <div className="flex flex-col md:flex-col text-pink-900 mt-7">
                <div className="ml-10 ">
                <UserCircleIcon className="h-44 w-auto md:h-22" />
                <h1 className=" ml-10 mt-3  text-3xl md:text-lg text-pink-900">{session?.data?.username}</h1>
                </div>
            </div>
            <div className="flex flex-col md:flex-col ml-8 mt-12">
            <h1 className="text-4xl md:text-2xl text-pink-950">{session?.data?.email}</h1>
            <h2 className="text-pink-800 mt-2 text-lg">{session?.data?.fullname}</h2>
            <button className="bg-pink-700 mt-3 hover:bg-pink-900 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="button">
                New Journal
            </button>
            <hr className="mt-8 border-solid border-black" />
           
            </div>
            
        </div>
        
    )
}