'use client'
import React,{useState} from "react"
import { Textarea } from "@/components/ui/textarea"
import { Input } from "@/components/ui/input"
import axios from "axios"
import { useSession } from "next-auth/react"
import { Toast, toast } from "react-toastify"

export default function JournalForm(){
    const {session} = useSession()
    const [formData, setFormData] = useState({
        title: "",
        content: "",
        userId: session?.data?.id
    })
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            let newFormdata = {
                ...formData,
            }
            const response = await axios.post("http://localhost:5103/api/Journal/newJournal", newFormdata)
            console.log(response)
            toast.success("Journal added successfully!")
        } catch (error) {
            console.log(error);
            toast.error("an error occurred!")
        }
    }
    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value

        const currentInputFieldData = {
            [name] : value
        }
        const updatedData = {
            ...formData,
            ...currentInputFieldData,
        }
        setFormData(updatedData)
    }
    return(
        <div>
            <h1>Journal Form</h1>
            <Input 
            onChange={handleChange}
            name="title"
            type="text"
            className="mt-4" placeholder="type title here" />
            <Textarea 
            onChange={handleChange}
            name="content"
            type="text"
            className="mt-4" placeholder="type content here" />
            <button 
             type="button"
             className="mt-4 inline-flex justify-center rounded-md border border-transparent bg-pink-100 px-4 py-2 text-sm font-medium text-pink-900 hover:bg-red-200 focus:outline-none focus-visible:ring-2 focus-visible:ring-red-500 focus-visible:ring-offset-2"
             onClick={handleSubmit}
            >Create</button>
        </div>
    )
}
