"use client"
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert"
import { Terminal } from "lucide-react"
import { DeleteIcon, EditIcon } from "lucide-react"
import { useSession } from "next-auth/react"
import axios from "axios"
import React from "react"

export default function Journals() {
    const [data, setData] = React.useState()
    const session = useSession()

    React.useEffect(() => {
        async function getJournals () {
            try {
                console.log(session)
                const response = await axios.get(`http://localhost:5103/api/Journal/`)
                console.log(response);
                setData(response.data)
            } catch (error) {
                console.log(error)
            }
        }
        getJournals()
    }, [session.status])
    return(
      <div>
        {data?.map((data) => (
        <Alert>
        {/* <Terminal className="h-4 w-4" /> */}
        <AlertTitle>{data.title}</AlertTitle>
        <AlertDescription>
          {data.content}
          <div className="flex flex-row gap-3">
          <DeleteIcon className="mt-6 text-red-500"/>
          <EditIcon className="mt-6 text-red-500"/>
          </div>
          
        </AlertDescription>
        
      </Alert>
    ))}
      </div>
    )
}