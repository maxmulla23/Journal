'use client'
import React,{useState} from "react"
import { Textarea } from "@/components/ui/textarea"
import { Input } from "@/components/ui/input"
import axios from "axios"

export default function JournalForm(){
    return(
        <div>
            <h1>Journal Form</h1>
            <Input className="mt-4" placeholder="type title here" />
            <Textarea className="mt-4" placeholder="type content here" />
            <button 
             type="button"
             className="mt-4 inline-flex justify-center rounded-md border border-transparent bg-pink-100 px-4 py-2 text-sm font-medium text-pink-900 hover:bg-red-200 focus:outline-none focus-visible:ring-2 focus-visible:ring-red-500 focus-visible:ring-offset-2"
             
            >Create</button>
        </div>
    )
}
