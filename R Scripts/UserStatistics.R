library(httr)
library(chron)

url <- "http://localhost:5000/user_statistics"

# ------------------------------ FUNCTIONS -------------------------------------

named_empty_list <- function(mylist.names) {
  emptyList <- vector(mode = "list", length = length(mylist.names))
  names(emptyList) <- mylist.names
  return(emptyList)
}

mean_times_value <- function(value.list) {
  # ifelse(condizione, se vero, se falso)
  ifelse(
    is.na(value.list),
    return(NA),
    return(mean(times(value.list)))
  )
}

max_list_value <- function(list) {
  act_max <- 0
  for(i in 1:length(list)) {
    label <- names(list)[i]
    sublist <- list[[label]]
    tmp_max <- max(as.vector(as.numeric(sublist)))
    if(act_max < tmp_max & !is.na(tmp_max))
      act_max <- tmp_max
  }
  return(act_max)
}

# -------------------------------- MAIN ----------------------------------------

repeat {
  
  # ---- Inserimento corretto nome utente ----
  user.name <- ""
  
  repeat {
    
    cat("\nEnter the name of the user whose statistics you want: ")
    user.name <- readLines("stdin", n = 1)
    user.name <- toupper(user.name)
    
    if(user.name == "") {
      
      cat("\nThe name of the user can't be empty!\n")
      
    } else break
    
  }
  
  # ---- Esecuzione REST POST ----
  resp <- POST(url, body = list(name = user.name), encode = "json")
  
  if(status_code(resp) == 201) {
    
    # ---- Estrazione dati utili ----
    user.data <- content(resp, type = "application/json") 
    # per vedere la struttura di un oggetto usare print(str(object))
    
    list.names <- c("EASY", "NORMAL", "HARD")
    user.scores <- named_empty_list(list.names)
    user.times <- named_empty_list(list.names)
    
    for(i in 1:length(user.data)) {

      difficult <- names(user.data)[i]
      current.list <- get(difficult, user.data)
      current.list.length <- length(current.list)

      if(current.list.length != 0) {
        for(j in 1:current.list.length) {
          user.scores[[difficult]][[j]] <- current.list[[j]]$score
          user.times[[difficult]][[j]] <- substr(current.list[[j]]$time, 1, nchar(current.list[[j]]$time) - 3)
        }
      } else {
        user.scores[[difficult]] <- NA
        user.times[[difficult]] <- NA
      }
    }
    
    # ---- Calcolo e stampa statistiche e grafici ----
    
    mean_scores <- list(
      easy = round(mean(as.numeric(user.scores$EASY)), 2),
      normal = round(mean(as.numeric(user.scores$NORMAL)), 2),
      hard = round(mean(as.numeric(user.scores$HARD)), 2)
    )
    mean_times <- list(
      easy = mean_times_value(user.times$EASY),
      normal = mean_times_value(user.times$NORMAL),
      hard = mean_times_value(user.times$HARD)
    )
    
    # Stampa dei valori medi per le varie difficoltà
    
    writeLines(paste0(
      "\n", user.name,"'s Average Scores:",
      "\n - Easy:\t", mean_scores$easy,
      "\n - Normal:\t", mean_scores$normal,
      "\n - Hard:\t", mean_scores$hard
    ))
    writeLines(paste0(
      "\n", user.name,"'s Average Times:",
      "\n - Easy:\t", mean_times$easy,
      "\n - Normal:\t", mean_times$normal,
      "\n - Hard:\t", mean_times$hard
    ))
    
    cat("\nWARNING!: any NA values simply mean that there is no data\n")
    
    # Apertura file jpeg
    path <- paste("./Plots/", user.name, ".jpeg")
    jpeg(filename = path)
    
    # Plot grafico e linee
    is_first <- TRUE
    
    for(i in 1:length(user.scores)) {
      difficult <- names(user.scores)[i]
      current_list <- user.scores[[difficult]]
      current_length <- length(current_list)
      color = switch(
        difficult,
        "EASY" = "yellow",
        "NORMAL" = "blue",
        "HARD" = "red"
      )
      
      if(current_length >= 1 & isTRUE(is_first)) {
        max_score <- max_list_value(user.scores)
        max_length <- max(sapply(user.scores, length))
        plot(seq(1:current_length), current_list, type = "b", pch = 16, cex = 1.5, col = color, xlab = "n° partita", ylab = "score", xlim = c(1, (max_length + 2)), ylim = c(0, (max_score + 100)))
        is_first <- FALSE
      } 
      else if(current_length >= 1 & isFALSE(is_first)) {
        lines(seq(1:current_length), current_list,  type = "b", pch = 16, cex = 1.5, col = color)
      }
      
      # Legenda grafico
      legend("topright", legend = c("Easy", "Normal", "Hard"), col = c("yellow", "blue", "red"), lty = c(1, 1, 1), cex = 0.8)
    }
    
    cat(paste0("\n(To see the updated plot go to ../PokémonMemory/Rscripts/Plots/", user.name, ".jpeg)\n"))
    
  } else
    
    cat("\nThe searched user is not present\n")
  
  # ---- Richiesta di terminazione script ----
  repeat {
    
    cat("\nDo you want to do another search? [Y/N]: ")
    continue <- readLines("stdin", n = 1)
    
    if(continue == "Y" | continue == "y" | continue == "N" | continue == "n")
      
      break
      
    else
      
      cat("\nWrong syntax: type only 'y'/'Y' or 'n'/'N'\n")
    
  }
  
  if(continue == "N" | continue == "n")
    
    break
}